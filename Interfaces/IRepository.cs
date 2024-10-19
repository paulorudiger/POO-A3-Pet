using POO_A4.Database;
using System.Collections;
using System.Collections.Generic;

namespace POO_A4.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //  protected readonly PetDbContext _context;

        //   protected abstract void ValidateAdd();
        //protected abstract void ValidateDelete();

        public void Add(T entity);

        public void Update(T entity);

        public void Delete(T entity);

        public T GetById(int id);

        public IEnumerable<T> GetAll();
    }
}