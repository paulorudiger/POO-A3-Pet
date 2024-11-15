using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using POO_A4.Services.Mappers;

namespace POO_A4.Services.Parsers
{
    // A classe ProductParser é responsável por realizar a conversão de um ProductDTO para a entidade Product.
    // Ela utiliza o AutoMapper para facilitar o processo de transformação de objetos de tipos diferentes.
    public class ProductParser
    {
        // A interface IMapper é usada para mapear objetos entre tipos diferentes (neste caso, entre ProductDTO e Product).
        private readonly IMapper _mapper;

        // O construtor configura o AutoMapper, criando uma instância do IMapper.
        // O perfil de mapeamento `ProductMapper` é adicionado para definir como os tipos Product e ProductDTO serão convertidos.
        public ProductParser()
        {
            // Cria a configuração do AutoMapper, registrando o perfil de mapeamento do ProductMapper.
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductMapper>(); // Adiciona o perfil de mapeamento específico para Product.
            });
            // Cria a instância do IMapper usando a configuração definida.
            _mapper = config.CreateMapper();
        }

        // Método ParseProduct converte um objeto ProductDTO para a entidade Product.
        // O método utiliza o AutoMapper para realizar o mapeamento entre os tipos.
        public Product ParseProduct(ProductDTO dto)
        {
            // Utiliza o AutoMapper para converter o DTO (ProductDTO) em uma entidade (Product).
            return _mapper.Map<Product>(dto); // Retorna a entidade mapeada.
        }
    }
}