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
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly ProductParser _parser;

        public ProductService(PetDbContext dbcontext)
        {
            _repository = new Repository<Product>(dbcontext);
            _parser = new ProductParser();
        }

        public Product Add(ProductDTO dto)
        {
            dto.productid = GetNextProductidValue();

            var validator = new ProductValidator();
            validator.ValidateAndThrow(dto);

            var entity = _parser.ParseProduct(dto);

            _repository.Add(entity);

            return entity;
        }

        public void Delete(int productId)
        {
            var entity = _repository.GetById(productId);
            if (entity == null)
            {
                throw new KeyNotFoundException("Product  not found");
            }

            _repository.Delete(entity);
        }

        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product GetById(int productId)
        {
            var entity = _repository.GetById(productId);
            if (entity == null)
            {
                throw new KeyNotFoundException("Product  not found");
            }

            return entity;
        }

        public Product Update(ProductDTO dto)
        {
            var validator = new ProductValidator();
            validator.ValidateAndThrow(dto);

            var id = dto.productid;
            var existingEntity = _repository.GetById(id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Product  not found");
            }

            var updatedEntity = _parser.ParseProduct(dto);
            updatedEntity.productid = id;

            _repository.Update(updatedEntity);
            return updatedEntity;
        }

        public int GetNextProductidValue()
        {
            var getAll = _repository.GetAll();

            // Lógica que vai controlar a PrimaryKey
            if (!getAll.Any())
            {
                return 1;
            }
            return getAll.Max(p => p.productid) + 1;
        }
    }
}