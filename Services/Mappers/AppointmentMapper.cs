using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;

namespace POO_A3_Pet.Services.Mappers
{
    public class AppointmentMapper : Profile
    {
        public AppointmentMapper()
        {
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
        }
    }
}