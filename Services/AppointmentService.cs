using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components.Forms.Mapping;
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

namespace POO_A3_Pet.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _repository;
        private readonly AppointmentParser _parser;

        //private readonly ILogger _logger;

        public AppointmentService(PetDbContext context, AppointmentParser parser)
        {
            _parser = parser;
            _repository = new Repository<Appointment>(context);
        }

        public void Add(AppointmentDTO dto)
        {
            // TODO: Ver se não está orientado a aspectos
            var validator = new AppointmentValidator();
            validator.ValidateAndThrow(dto);

            var entity = _parser.ParseAppointment(dto);

            _repository.Add(entity);
        }

        public void Delete(AppointmentDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public Appointment GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(AppointmentDTO dto)
        {
            throw new System.NotImplementedException();
        }
    }
}