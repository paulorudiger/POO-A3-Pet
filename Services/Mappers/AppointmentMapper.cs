using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;

namespace POO_A3_Pet.Services.Mappers
{
    // A classe AppointmentMapper herda de Profile, que é uma classe base fornecida pelo AutoMapper.
    // O AutoMapper é uma biblioteca que simplifica a conversão de objetos entre tipos diferentes, como a conversão de entidades para DTOs e vice-versa.
    public class AppointmentMapper : Profile
    {
        // O construtor da classe define o mapeamento entre a entidade Appointment e o DTO AppointmentDTO.
        // O método CreateMap é utilizado para definir como um tipo será mapeado para outro.
        // O mapeamento é bidirecional, ou seja, a conversão pode ser feita tanto de Appointment para AppointmentDTO quanto de AppointmentDTO para Appointment.
        public AppointmentMapper()
        {
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            // CreateMap<Appointment, AppointmentDTO> cria o mapeamento de Appointment para AppointmentDTO.
            // ReverseMap() cria o mapeamento inverso de AppointmentDTO para Appointment, tornando o mapeamento bidirecional.
        }
    }
}