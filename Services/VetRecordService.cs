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
    // Manter ficha veterinária
    public class VetRecordService : IVetRecordService
    {
        private readonly IRepository<VetRecord> _repository;
        private readonly VetRecordParser _parser;

        public VetRecordService(PetDbContext dbcontext)
        {
            _repository = new Repository<VetRecord>(dbcontext);
            _parser = new VetRecordParser();
        }

        public VetRecord Add(VetRecordDTO dto)
        {
            var validator = new VetRecordValidator();
            validator.ValidateAndThrow(dto);
            dto.vetrecordid = GetNextVetRecordIdValue();
            var entity = _parser.ParseVetRecord(dto);
            _repository.Add(entity);

            return entity;
        }

        public void Delete(int vetRecordId)
        {
            var entity = _repository.GetById(vetRecordId);
            if (entity == null)
            {
                throw new KeyNotFoundException("Vet record not found");
            }

            _repository.Delete(entity);
        }

        public IEnumerable<VetRecord> GetAll()
        {
            return _repository.GetAll();
        }

        public VetRecord GetById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Vet record not found");
            }

            return entity;
        }

        public VetRecord Update(VetRecordDTO dto)
        {
            var validator = new VetRecordValidator();
            validator.ValidateAndThrow(dto);

            var id = dto.vetrecordid;
            var existingEntity = _repository.GetById(id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Vet record not found");
            }

            var updatedEntity = _parser.ParseVetRecord(dto);
            updatedEntity.vetrecordid = id;

            _repository.Update(updatedEntity);
            return updatedEntity;
        }

        public int GetNextVetRecordIdValue()
        {
            var getAll = _repository.GetAll();

            if (!getAll.Any())
            {
                return 1;
            }
            return getAll.Max(v => v.vetrecordid) + 1;
        }
    }
}