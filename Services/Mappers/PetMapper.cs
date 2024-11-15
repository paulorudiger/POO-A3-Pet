using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;

namespace POO_A4.Services.Mappers
{
    // A classe PetMapper herda de Profile, que é uma classe base fornecida pelo AutoMapper.
    // O AutoMapper é uma biblioteca que simplifica a conversão de objetos entre tipos diferentes, como a conversão de entidades para DTOs e vice-versa.
    public class PetMapper : Profile
    {
        // O construtor da classe define o mapeamento entre a entidade Pet e o DTO PetDTO.
        // O método CreateMap é utilizado para definir como um tipo será mapeado para outro.
        // O mapeamento é bidirecional, ou seja, a conversão pode ser feita tanto de Pet para PetDTO quanto de PetDTO para Pet.
        public PetMapper()
        {
            CreateMap<Pet, PetDTO>().ReverseMap();
            // CreateMap<Pet, PetDTO> cria o mapeamento de Pet para PetDTO.
            // ReverseMap() cria o mapeamento inverso de PetDTO para Pet, tornando o mapeamento bidirecional.
        }
    }
}