using FluentValidation;
using FluentValidation.Results;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Database.Repositories;
using POO_A4.Services.Interfaces;
using POO_A4.Services.Mappers;
using POO_A4.Services.Parsers;
using POO_A4.Services.Validators;
using POO_A4.Database;
using POO_A4.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using POO_A4.Interfaces;

namespace POO_A4.Services
{
    // A classe ProductService implementa a interface IProductService e fornece os métodos necessários para
    // manipulação de produtos no sistema.
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly ProductParser _parser;

        // O construtor recebe o PetDbContext e inicializa o repositório e o parser para produtos.
        public ProductService(PetDbContext dbcontext)
        {
            _repository = new Repository<Product>(dbcontext); // Cria a instância do repositório.
            _parser = new ProductParser(); // Cria a instância do parser para converter DTOs em entidades.
        }

        // Método responsável por adicionar um novo produto.
        public Product Add(ProductDTO dto)
        {
            var validator = new ProductValidator();
            validator.ValidateAndThrow(dto); // Valida o DTO antes de processar.
            dto.productid = GetNextProductidValue(); // Define o próximo ID para o produto.
            var entity = _parser.ParseProduct(dto); // Converte o DTO para a entidade Product.

            _repository.Add(entity); // Adiciona a entidade ao repositório.

            return entity; // Retorna a entidade recém-criada.
        }

        // Método para excluir um produto pelo seu ID.
        public void Delete(int productId)
        {
            var entity = _repository.GetById(productId); // Busca o produto pelo ID.
            if (entity == null)
            {
                throw new KeyNotFoundException("Product not found"); // Lança exceção se o produto não for encontrado.
            }

            _repository.Delete(entity); // Exclui o produto do repositório.
        }

        // Método para obter todos os produtos.
        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll(); // Retorna todos os produtos do repositório.
        }

        // Método para buscar um produto pelo ID.
        public Product GetById(int productId)
        {
            var entity = _repository.GetById(productId); // Busca o produto pelo ID.
            if (entity == null)
            {
                throw new KeyNotFoundException("Product not found"); // Lança exceção se o produto não for encontrado.
            }

            return entity; // Retorna o produto encontrado.
        }

        // Método para atualizar um produto.
        public Product Update(ProductDTO dto)
        {
            var validator = new ProductValidator();
            validator.ValidateAndThrow(dto); // Valida o DTO antes de processar.

            var id = dto.productid;
            var existingEntity = _repository.GetById(id); // Busca a entidade existente.
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Product not found"); // Lança exceção se o produto não for encontrado.
            }

            var updatedEntity = _parser.ParseProduct(dto); // Converte o DTO para a entidade Product.
            updatedEntity.productid = id; // Garante que o ID do produto não seja alterado.

            _repository.Update(updatedEntity); // Atualiza o produto no repositório.
            return updatedEntity; // Retorna o produto atualizado.
        }

        // Método para calcular o próximo valor do ID para o produto.
        public int GetNextProductidValue()
        {
            var getAll = _repository.GetAll(); // Obtém todos os produtos do repositório.

            // Lógica para controlar a PrimaryKey.
            if (!getAll.Any())
            {
                return 1; // Se não houver produtos, começa com ID 1.
            }
            return getAll.Max(p => p.productid) + 1; // Retorna o próximo ID sequencial.
        }
    }
}