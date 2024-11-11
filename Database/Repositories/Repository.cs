using Microsoft.EntityFrameworkCore;
using POO_A4.Database;
using POO_A4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POO_A3_Pet.Database.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PetDbContext _context;

        public Repository(PetDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(T entity)
        {
            // ValidateAdd()
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void Update(T entity)
        {
            // ValidateUpdate
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Find<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public int GetNextIdValue()
        {
            var dbSet = _context.Set<T>();

            if (!dbSet.Any())
            {
                return 1; // Retorna 1 se não houver registros
            }

            // Tenta encontrar uma propriedade de ID comum dinamicamente
            var idProperty = typeof(T).GetProperties()
                .FirstOrDefault(prop => prop.Name.ToLower().EndsWith("id") && prop.PropertyType == typeof(int));

            if (idProperty == null)
            {
                throw new InvalidOperationException("A propriedade de ID não foi encontrada na entidade.");
            }

            // Usa reflexão para encontrar o maior ID
            var maxId = dbSet
                .Select(entity => (int)idProperty.GetValue(entity, null))
                .Max();

            return maxId + 1; // Retorna o próximo ID
        }
    }
}