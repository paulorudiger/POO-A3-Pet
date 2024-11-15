using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;

namespace POO_A4.Services.Mappers
{
    // A classe ProductMapper herda de Profile, que é uma classe base fornecida pelo AutoMapper.
    // O AutoMapper é uma biblioteca que simplifica a conversão de objetos entre tipos diferentes, como a conversão de entidades para DTOs e vice-versa.
    public class ProductMapper : Profile
    {
        // O construtor da classe define o mapeamento entre a entidade Product e o DTO ProductDTO.
        // O método CreateMap é utilizado para definir como um tipo será mapeado para outro.
        // O mapeamento é bidirecional, ou seja, a conversão pode ser feita tanto de Product para ProductDTO quanto de ProductDTO para Product.
        public ProductMapper()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            // CreateMap<Product, ProductDTO> cria o mapeamento de Product para ProductDTO.
            // ReverseMap() cria o mapeamento inverso de ProductDTO para Product, tornando o mapeamento bidirecional.
        }
    }
}