using FluentValidation;
using POO_A4.Database;
using POO_A4.Services.Validators;
using POO_A4.Services.DTOs;
using System.Collections.Generic;
using System.Linq;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Database.Repositories;
using POO_A3_Pet.Services.Interfaces;
using POO_A4.Interfaces;
using POO_A4.Services.Parsers;

namespace POO_A4.Services
{
    // A classe VetRecordService implementa a interface IVetRecordService e fornece os métodos necessários para
    // manipulação de registros veterinários (VetRecords) no sistema.
    public class VetRecordService : IVetRecordService
    {
        private readonly IRepository<VetRecord> _repository;
        private readonly VetRecordParser _parser;

        // O construtor recebe o PetDbContext e inicializa o repositório e o parser para VetRecords.
        public VetRecordService(PetDbContext dbcontext)
        {
            _repository = new Repository<VetRecord>(dbcontext); // Cria a instância do repositório.
            _parser = new VetRecordParser(); // Cria a instância do parser que converte VetRecordDTO em VetRecord.
        }

        // Método responsável por adicionar um novo registro veterinário.
        public VetRecord Add(VetRecordDTO dto)
        {
            var validator = new VetRecordValidator();
            validator.ValidateAndThrow(dto); // Valida o DTO antes de processar.
            dto.vetrecordid = GetNextVetRecordIdValue(); // Define o próximo ID do registro veterinário.
            var entity = _parser.ParseVetRecord(dto); // Converte o DTO para uma entidade VetRecord.
            _repository.Add(entity); // Adiciona a entidade ao repositório (banco de dados).

            return entity; // Retorna a entidade recém-criada.
        }

        // Método para excluir um registro veterinário pelo seu ID.
        public void Delete(int vetRecordId)
        {
            var entity = _repository.GetById(vetRecordId); // Busca o registro pelo ID.
            if (entity == null)
            {
                throw new KeyNotFoundException("Vet record not found"); // Lança exceção se o registro não for encontrado.
            }

            _repository.Delete(entity); // Exclui o registro do repositório.
        }

        // Método para obter todos os registros veterinários.
        public IEnumerable<VetRecord> GetAll()
        {
            return _repository.GetAll(); // Retorna todos os registros do repositório.
        }

        // Método para buscar um registro veterinário pelo ID.
        public VetRecord GetById(int id)
        {
            var entity = _repository.GetById(id); // Busca o registro pelo ID.
            if (entity == null)
            {
                throw new KeyNotFoundException("Vet record not found"); // Lança exceção se o registro não for encontrado.
            }

            return entity; // Retorna o registro encontrado.
        }

        // Método para atualizar um registro veterinário.
        public VetRecord Update(VetRecordDTO dto)
        {
            var validator = new VetRecordValidator();
            validator.ValidateAndThrow(dto); // Valida o DTO antes de processar.

            var id = dto.vetrecordid;
            var existingEntity = _repository.GetById(id); // Busca a entidade existente.
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Vet record not found"); // Lança exceção se o registro não for encontrado.
            }

            var updatedEntity = _parser.ParseVetRecord(dto); // Converte o DTO para a entidade VetRecord.
            updatedEntity.vetrecordid = id; // Garante que o ID do registro não seja alterado.

            _repository.Update(updatedEntity); // Atualiza a entidade no repositório.
            return updatedEntity; // Retorna a entidade atualizada.
        }

        // Método para calcular o próximo valor do ID para o registro veterinário.
        public int GetNextVetRecordIdValue()
        {
            var getAll = _repository.GetAll(); // Obtém todos os registros do repositório.

            if (!getAll.Any()) // Se não houver registros, começa com ID 1.
            {
                return 1;
            }
            return getAll.Max(v => v.vetrecordid) + 1; // Retorna o próximo ID sequencial.
        }
    }
}