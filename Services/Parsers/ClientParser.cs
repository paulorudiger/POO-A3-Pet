using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using POO_A4.Services.Mappers;

namespace POO_A4.Services.Parsers
{
    public class ClientParser
    {
        private readonly IMapper _mapper;

        public ClientParser()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClientMapper>();
            });
            _mapper = config.CreateMapper();
        }

        public Client ParseClient(ClientDTO dto)
        {
            // Utiliza o AutoMapper para converter o DTO para a entidade
            return _mapper.Map<Client>(dto);
        }
    }
}