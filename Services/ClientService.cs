using FluentValidation;
using FluentValidation.Results;
using POO_A4.Database;
using POO_A4.Services.Interfaces;
using POO_A4.Services.Mappers;
using POO_A4.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Database.Repositories;
using POO_A4.Interfaces;
using POO_A4.Services.Parsers;
using POO_A4.Services.Validators;

namespace POO_A4.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _repository;
        private readonly ClientParser _parser;

        public ClientService(PetDbContext dbcontext)
        {
            _repository = new Repository<Client>(dbcontext);
            _parser = new ClientParser();
        }

        public Client Add(ClientDTO dto)
        {
            dto.clientid = GetNextClientIdValue();
            var validator = new ClientValidator();
            // TODO: descomentar após testes
            //  validator.ValidateAndThrow(dto);

            var entity = _parser.ParseClient(dto);
            _repository.Add(entity);

            return entity;
        }

        public void Delete(int clientId)
        {
            var entity = _repository.GetById(clientId);
            if (entity == null)
            {
                throw new KeyNotFoundException("Client not found");
            }

            _repository.Delete(entity);
        }

        public IEnumerable<Client> GetAll()
        {
            return _repository.GetAll();
        }

        public Client GetById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Client not found");
            }

            return entity;
        }

        public Client Update(ClientDTO dto)
        {
            var validator = new ClientValidator();
            // TODO: descomentar após testes
            //validator.ValidateAndThrow(dto);

            var id = dto.clientid;
            var existingEntity = _repository.GetById(id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Client not found");
            }

            var updatedEntity = _parser.ParseClient(dto);
            updatedEntity.clientid = id;

            _repository.Update(updatedEntity);
            return updatedEntity;
        }

        public int GetNextClientIdValue()
        {
            var getAll = _repository.GetAll();

            if (!getAll.Any())
            {
                return 1;
            }
            return getAll.Max(c => c.clientid) + 1;
        }
    }
}