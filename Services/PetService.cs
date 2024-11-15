using FluentValidation;
using FluentValidation.Results;
using POO_A4.Database;
using POO_A4.Services.Interfaces;
using POO_A4.Services.Mappers;
using POO_A4.Services.Parsers;
using POO_A4.Services.Validators;
using POO_A4.Services.DTOs;
using System.Collections.Generic;
using System.Linq;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Database.Repositories;
using POO_A4.Interfaces;

namespace POO_A4.Services
{
    // A classe PetService implementa a interface IPetService e é responsável por fornecer os métodos
    // necessários para manipular os animais (Pets) no sistema.
    // Ela encapsula a lógica relacionada a operações CRUD, validações e regras de negócios para os pets.
    public class PetService : IPetService
    {
        // O repositório _repository é uma instância do repositório genérico para a entidade Pet.
        // Ele abstrai o acesso ao banco de dados e fornece métodos para realizar operações CRUD.
        private readonly IRepository<Pet> _repository;

        // O parser _parser é uma instância da classe PetParser, que é responsável por converter os DTOs em entidades.
        private readonly PetParser _parser;

        // O construtor recebe o contexto do banco de dados (PetDbContext) e inicializa o repositório e o parser.
        public PetService(PetDbContext dbcontext)
        {
            _repository = new Repository<Pet>(dbcontext);  // Cria uma instância do repositório para Pet.
            _parser = new PetParser();  // Cria uma instância do parser para converter o DTO em entidades.
        }

        // Método responsável por adicionar um novo pet.
        // Primeiro, valida o DTO com o FluentValidation, gera um novo ID para o pet e cria a entidade de pet.
        public Pet Add(PetDTO dto)
        {
            // Validação do DTO utilizando FluentValidation.
            var validator = new PetValidator();
            validator.ValidateAndThrow(dto);  // Lança uma exceção se a validação falhar.

            // Geração do próximo ID para o pet.
            dto.petid = GetNextPetIdValue();

            // Converte o DTO para a entidade Pet utilizando o parser.
            var entity = _parser.ParsePet(dto);

            // Adiciona a entidade ao repositório (banco de dados).
            _repository.Add(entity);

            return entity;  // Retorna a entidade recém-criada.
        }

        // Método para excluir um pet.
        // Se o pet não for encontrado, lança uma exceção.
        public void Delete(int petId)
        {
            var entity = _repository.GetById(petId);  // Busca o pet pelo ID.
            if (entity == null)
            {
                throw new KeyNotFoundException("Pet not found");  // Lança exceção se o pet não for encontrado.
            }

            // Deleta o pet do repositório (banco de dados).
            _repository.Delete(entity);
        }

        // Método para obter todos os pets do banco de dados.
        public IEnumerable<Pet> GetAll()
        {
            return _repository.GetAll();  // Retorna todos os pets.
        }

        // Método para obter um pet pelo seu ID.
        // Se o pet não for encontrado, lança uma exceção.
        public Pet GetById(int id)
        {
            var entity = _repository.GetById(id);  // Busca o pet pelo ID.
            if (entity == null)
            {
                throw new KeyNotFoundException("Pet not found");  // Lança exceção se o pet não for encontrado.
            }

            return entity;  // Retorna o pet encontrado.
        }

        // Método para atualizar um pet existente.
        // O pet é validado e, em seguida, atualizado no repositório.
        public Pet Update(PetDTO dto)
        {
            // Validação do DTO utilizando FluentValidation.
            var validator = new PetValidator();
            validator.ValidateAndThrow(dto);  // Lança uma exceção se a validação falhar.

            var id = dto.petid;
            var existingEntity = _repository.GetById(id);  // Busca o pet pelo ID.
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Pet not found");  // Lança exceção se o pet não for encontrado.
            }

            // Converte o DTO para a entidade Pet utilizando o parser.
            var updatedEntity = _parser.ParsePet(dto);
            updatedEntity.petid = id;  // Garante que o ID do pet não seja alterado.

            // Atualiza o pet no repositório (banco de dados).
            _repository.Update(updatedEntity);
            return updatedEntity;  // Retorna o pet atualizado.
        }

        // Método que calcula o próximo valor do ID para o pet.
        // Ele verifica o maior ID existente no banco de dados e retorna o próximo valor sequencial.
        public int GetNextPetIdValue()
        {
            var getAll = _repository.GetAll();

            // Lógica para controlar a PrimaryKey.
            if (!getAll.Any())
            {
                return 1;  // Retorna 1 se não houver pets no banco de dados.
            }
            return getAll.Max(p => p.petid) + 1;  // Retorna o próximo ID sequencial.
        }
    }
}