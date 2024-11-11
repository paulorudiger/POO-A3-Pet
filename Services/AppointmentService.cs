using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.EntityFrameworkCore;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Database.Repositories;
using POO_A3_Pet.Services.Interfaces;
using POO_A3_Pet.Services.Mappers;
using POO_A3_Pet.Services.Parsers;
using POO_A3_Pet.Services.Validators;
using POO_A4.Database;
using POO_A4.Interfaces;
using POO_A4.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POO_A3_Pet.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _repository;
        private readonly AppointmentParser _parser;

        public AppointmentService(PetDbContext dbcontext)
        {
            _repository = new Repository<Appointment>(dbcontext);
            _parser = new AppointmentParser();
        }

        public Appointment Add(AppointmentDTO dto)
        {
            dto.appointmentid = GetNextAppointmentidValue();
            //    _repository.GetNextIdValue();
            var validator = new AppointmentValidator();
            validator.ValidateAndThrow(dto);

            // if consultando no BD o tipo enumerado do productType

            var entity = _parser.ParseAppointment(dto);
            _repository.Add(entity);

            return entity;
        }

        public void Delete(int appointmentid)
        {
            var entity = _repository.GetById(appointmentid);
            // TODO: melhorar throw
            if (entity == null)
            {
                throw new KeyNotFoundException("Appointment not found");
            }

            _repository.Delete(entity);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _repository.GetAll();
        }

        public Appointment GetById(int id)
        {
            var entity = _repository.GetById(id);
            // TODO: melhorar throw
            if (entity == null)
            {
                throw new KeyNotFoundException("Appointment not found");
            }

            return entity;
        }

        public Appointment Update(AppointmentDTO dto)
        {
            var validator = new AppointmentValidator();
            validator.ValidateAndThrow(dto);

            var id = dto.appointmentid;
            var existingEntity = _repository.GetById(id);
            // TODO: melhorar throw
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Appointment not found");
            }

            var updatedEntity = _parser.ParseAppointment(dto);
            updatedEntity.appointmentid = id; // mantém o ID do registro existente // TODO: entender

            _repository.Update(updatedEntity);
            return updatedEntity;
        }

        public int GetNextAppointmentidValue()
        {
            var getAll = _repository.GetAll();

            // Lógica que vai controlar a PrimaryKey
            if (!getAll.Any())
            {
                return 1;
            }
            return getAll.Max(a => a.appointmentid) + 1;
        }
    }
}