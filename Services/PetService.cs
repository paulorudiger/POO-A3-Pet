using FluentValidation;
using FluentValidation.Results;
using POO_A4.Database;
using POO_A4.Services.Interfaces;
using POO_A4.Services.Mappers;
using POO_A4.Services.Validators;
using POO_A4.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Database.Repositories;
using POO_A4.Interfaces;
using POO_A4.Services.Parsers;

namespace POO_A4.Services
{
    public class PetService : IPetService
    {
        private readonly IRepository<Pet> _repository;
        private readonly PetParser _parser;

        public PetService(PetDbContext dbcontext)
        {
            _repository = new Repository<Pet>(dbcontext);
            _parser = new PetParser();
        }

        public Pet Add(PetDTO dto)
        {
            var validator = new PetValidator();
            validator.ValidateAndThrow(dto);

            dto.petid = GetNextPetIdValue();
            var entity = _parser.ParsePet(dto);
            _repository.Add(entity);

            return entity;
        }

        public void Delete(int petId)
        {
            var entity = _repository.GetById(petId);
            if (entity == null)
            {
                throw new KeyNotFoundException("Pet not found");
            }

            _repository.Delete(entity);
        }

        public IEnumerable<Pet> GetAll()
        {
            return _repository.GetAll();
        }

        public Pet GetById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Pet not found");
            }

            return entity;
        }

        public Pet Update(PetDTO dto)
        {
            var validator = new PetValidator();
            validator.ValidateAndThrow(dto);

            var id = dto.petid;
            var existingEntity = _repository.GetById(id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Pet not found");
            }

            var updatedEntity = _parser.ParsePet(dto);
            updatedEntity.petid = id;

            _repository.Update(updatedEntity);
            return updatedEntity;
        }

        public int GetNextPetIdValue()
        {
            var getAll = _repository.GetAll();

            if (!getAll.Any())
            {
                return 1;
            }
            return getAll.Max(p => p.petid) + 1;
        }
    }
}