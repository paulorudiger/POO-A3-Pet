using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using POO_A4.Services.Mappers;

namespace POO_A4.Services.Parsers
{
    public class PetParser
    {
        private readonly IMapper _mapper;

        public PetParser()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PetMapper>();
            });
            _mapper = config.CreateMapper();
        }

        public Pet ParsePet(PetDTO dto)
        {
            // Utiliza o AutoMapper para converter o DTO para a entidade
            return _mapper.Map<Pet>(dto);
        }
    }
}