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
    }
}