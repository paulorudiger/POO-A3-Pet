using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Services.Mappers;
using POO_A4.Services.DTOs;

namespace POO_A3_Pet.Services.Parsers
{
    // A classe AppointmentParser é responsável por realizar a conversão de um AppointmentDTO para a entidade Appointment.
    // Ela utiliza o AutoMapper para facilitar o processo de transformação de objetos de tipos diferentes.
    public class AppointmentParser
    {
        // A interface IMapper é usada para mapear objetos entre tipos diferentes (neste caso, entre AppointmentDTO e Appointment).
        private readonly IMapper _mapper;

        // O construtor da classe configura o AutoMapper e cria a instância do IMapper.
        // Ele adiciona o perfil de mapeamento do AppointmentMapper, que define como os tipos Appointment e AppointmentDTO serão convertidos.
        public AppointmentParser()
        {
            // Cria a configuração do AutoMapper, registrando o perfil do AppointmentMapper.
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AppointmentMapper>(); // Adiciona o perfil de mapeamento específico para Appointment.
            });
            // Cria a instância do IMapper usando a configuração definida.
            _mapper = config.CreateMapper();
        }

        // Método ParseAppointment converte um objeto AppointmentDTO para a entidade Appointment.
        // O método utiliza o AutoMapper para realizar o mapeamento entre os tipos.
        public Appointment ParseAppointment(AppointmentDTO dto)
        {
            // Utiliza o AutoMapper para converter o DTO (AppointmentDTO) em uma entidade (Appointment).
            return _mapper.Map<Appointment>(dto); // Retorna a entidade mapeada.
        }
    }
}