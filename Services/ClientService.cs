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
    // A classe ClientService implementa a interface IClientService e é responsável por fornecer os métodos
    // necessários para manipular os clientes no sistema.
    // Ela abstrai a lógica de negócios e operações CRUD (Create, Read, Update, Delete) para a entidade Client.
    public class ClientService : IClientService
    {
        // O repositório _repository é uma instância do repositório genérico para a entidade Client.
        // Ele abstrai o acesso ao banco de dados e fornece métodos para realizar operações CRUD.
        private readonly IRepository<Client> _repository;

        // O parser _parser é uma instância da classe ClientParser, que é responsável por converter os DTOs em entidades.
        private readonly ClientParser _parser;

        // O construtor recebe o contexto do banco de dados (PetDbContext) e inicializa o repositório e o parser.
        public ClientService(PetDbContext dbcontext)
        {
            _repository = new Repository<Client>(dbcontext);  // Cria uma instância do repositório para Client.
            _parser = new ClientParser();  // Cria uma instância do parser para converter o DTO em entidades.
        }

        // Método responsável por adicionar um novo cliente.
        // Primeiro, valida o DTO com o FluentValidation, gera um novo ID para o cliente e cria a entidade de cliente.
        public Client Add(ClientDTO dto)
        {
            // Validação do DTO utilizando FluentValidation.
            var validator = new ClientValidator();
            validator.ValidateAndThrow(dto);  // Lança uma exceção se a validação falhar.

            // Geração do próximo ID para o cliente.
            dto.clientid = GetNextClientIdValue();

            // Converte o DTO para a entidade Client utilizando o parser.
            var entity = _parser.ParseClient(dto);

            // Adiciona a entidade ao repositório (banco de dados).
            _repository.Add(entity);

            return entity;  // Retorna a entidade recém-criada.
        }

        // Método para excluir um cliente.
        // Se o cliente não for encontrado, lança uma exceção.
        public void Delete(int clientId)
        {
            var entity = _repository.GetById(clientId);  // Busca o cliente pelo ID.
            if (entity == null)
            {
                throw new KeyNotFoundException("Client not found");  // Lança exceção se o cliente não for encontrado.
            }

            // Deleta o cliente do repositório (banco de dados).
            _repository.Delete(entity);
        }

        // Método para obter todos os clientes do banco de dados.
        public IEnumerable<Client> GetAll()
        {
            return _repository.GetAll();  // Retorna todos os clientes.
        }

        // Método para obter um cliente pelo seu ID.
        // Se o cliente não for encontrado, lança uma exceção.
        public Client GetById(int id)
        {
            var entity = _repository.GetById(id);  // Busca o cliente pelo ID.
            if (entity == null)
            {
                throw new KeyNotFoundException("Client not found");  // Lança exceção se o cliente não for encontrado.
            }

            return entity;  // Retorna o cliente encontrado.
        }

        // Método para atualizar um cliente existente.
        // O cliente é validado e, em seguida, atualizado no repositório.
        public Client Update(ClientDTO dto)
        {
            // Validação do DTO utilizando FluentValidation.
            var validator = new ClientValidator();
            validator.ValidateAndThrow(dto);  // Lança uma exceção se a validação falhar.

            var id = dto.clientid;
            var existingEntity = _repository.GetById(id);  // Busca o cliente pelo ID.
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Client not found");  // Lança exceção se o cliente não for encontrado.
            }

            // Converte o DTO para a entidade Client utilizando o parser.
            var updatedEntity = _parser.ParseClient(dto);
            updatedEntity.clientid = id;  // Garante que o ID do cliente não seja alterado.

            // Atualiza o cliente no repositório (banco de dados).
            _repository.Update(updatedEntity);
            return updatedEntity;  // Retorna o cliente atualizado.
        }

        // Método que calcula o próximo valor do ID para o cliente.
        // Ele verifica o maior ID existente no banco de dados e retorna o próximo valor sequencial.
        public int GetNextClientIdValue()
        {
            var getAll = _repository.GetAll();

            // Lógica para controlar a PrimaryKey.
            if (!getAll.Any())
            {
                return 1;  // Retorna 1 se não houver clientes no banco de dados.
            }
            return getAll.Max(c => c.clientid) + 1;  // Retorna o próximo ID sequencial.
        }
    }
}