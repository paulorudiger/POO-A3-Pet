using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using System.Collections.Generic;

namespace POO_A3_Pet.Services.Interfaces
{
    public interface IAppointmentService
    {
        // CRUD com parametro DTO

        public void Add(AppointmentDTO dto);

        public void Update(AppointmentDTO dto);

        public void Delete(AppointmentDTO dto);

        public Appointment GetById(int id);

        // public IEnumerable<T> GetAll();
    }
}