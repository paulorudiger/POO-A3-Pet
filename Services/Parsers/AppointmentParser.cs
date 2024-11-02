using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Services.Mappers;
using POO_A4.Services.DTOs;

namespace POO_A3_Pet.Services.Parsers
{
    public class AppointmentParser
    {
        private readonly IMapper _mapper;

        public AppointmentParser()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AppointmentMapper>();
            });
            _mapper = config.CreateMapper();
        }

        public Appointment ParseAppointment(AppointmentDTO dto)
        {
            // Utiliza o AutoMapper para converter o DTO para a entidade
            return _mapper.Map<Appointment>(dto);
        }
    }
}