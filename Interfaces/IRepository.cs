using POO_A4.Database;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace POO_A4.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //  protected readonly PetDbContext _context;

        //   protected abstract void ValidateAdd();
        //protected abstract void ValidateDelete();

        public void Add(T entity, PetDbContext dbContext)
        {
            // Posso fazer?
            // Classe abstrata?
            // ValidateAdd()
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Update(T entity, PetDbContext dbContext)
        {
            // ValidateUpdate
            dbContext.Update(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete(T entity, PetDbContext dbContext)
        {
            // ValidateRemove
            dbContext.Remove(entity);
        }

        public T GetById(int id, PetDbContext dbContext)
        {
            return dbContext.Find<T>(id);
        }

        public IEnumerable<T> GetAll(PetDbContext dbContext)
        {
            return dbContext.Set<T>().ToList();
        }
    }
}