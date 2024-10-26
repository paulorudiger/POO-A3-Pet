using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Database.Repositories;
using POO_A3_Pet.Services.Interfaces;
using POO_A4.Database;
using POO_A4.Interfaces;
using POO_A4.Services.DTOs;

namespace POO_A3_Pet.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _repository;

        //private readonly ILogger _logger;

        public AppointmentService(PetDbContext context)
        {
            // _service = service;
            _repository = new AppointmentRepository(context);
        }

        public void Add(AppointmentDTO dto)
        {
            throw new System.NotImplementedException();
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