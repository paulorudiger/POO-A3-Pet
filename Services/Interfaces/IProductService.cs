using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using System.Collections.Generic;

namespace POO_A4.Services.Interfaces
{
    public interface IProductService
    {
        // CRUD com parâmetro DTO

        public Product Add(ProductDTO dto);

        public Product Update(ProductDTO dto);

        public void Delete(int id);

        public Product GetById(int id);

        public IEnumerable<Product> GetAll();
    }
}