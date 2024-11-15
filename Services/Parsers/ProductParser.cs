using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using POO_A4.Services.Mappers;

namespace POO_A4.Services.Parsers
{
    public class ProductParser
    {
        private readonly IMapper _mapper;

        public ProductParser()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductMapper>();
            });
            _mapper = config.CreateMapper();
        }

        public Product ParseProduct(ProductDTO dto)
        {
            // Utiliza o AutoMapper para converter o DTO para a entidade Product
            return _mapper.Map<Product>(dto);
        }
    }
}