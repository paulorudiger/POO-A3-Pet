using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;

namespace POO_A4.Services.Mappers
{
    // A classe ClientMapper herda de Profile, que é uma classe base fornecida pelo AutoMapper.
    // O AutoMapper é uma biblioteca que simplifica a conversão de objetos entre tipos diferentes, como a conversão de entidades para DTOs e vice-versa.
    public class ClientMapper : Profile
    {
        // O construtor da classe define o mapeamento entre a entidade Client e o DTO ClientDTO.
        // O método CreateMap é utilizado para definir como um tipo será mapeado para outro.
        // O mapeamento é bidirecional, ou seja, a conversão pode ser feita tanto de Client para ClientDTO quanto de ClientDTO para Client.
        public ClientMapper()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            // CreateMap<Client, ClientDTO> cria o mapeamento de Client para ClientDTO.
            // ReverseMap() cria o mapeamento inverso de ClientDTO para Client, tornando o mapeamento bidirecional.
        }
    }
}