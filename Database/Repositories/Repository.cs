using Microsoft.EntityFrameworkCore;
using POO_A4.Database;
using POO_A4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POO_A3_Pet.Database.Repositories
{
    // A classe Repository implementa a interface IRepository<T> e fornece métodos genéricos para operações CRUD (Create, Read, Update, Delete).
    // A utilização de generics permite que o repositório seja reutilizável para qualquer tipo de entidade.
    // A classe segue o princípio de **abstração**, onde a lógica de manipulação de dados é isolada em um repositório genérico.
    public class Repository<T> : IRepository<T> where T : class
    {
        // O contexto do banco de dados é injetado no repositório, permitindo o acesso a todas as entidades no banco.
        // A dependência do contexto é injetada por meio do construtor, promovendo o princípio de **injeção de dependência**.
        protected readonly PetDbContext _context;

        // Construtor que recebe o contexto do banco de dados e o armazena em uma variável de classe.
        public Repository(PetDbContext dbContext)
        {
            _context = dbContext;
        }

        // Método para adicionar uma nova entidade ao banco de dados.
        // O método `Add` adiciona a entidade ao contexto e persiste as mudanças no banco de dados.
        public void Add(T entity)
        {
            // Possíveis validações poderiam ser adicionadas aqui, como `ValidateAdd()`.
            _context.Add(entity); // Adiciona a entidade ao contexto do banco de dados.
            _context.SaveChanges(); // Persiste as alterações no banco de dados.
        }

        // Método para remover uma entidade do banco de dados.
        public void Delete(T entity)
        {
            _context.Remove(entity); // Remove a entidade do contexto. Não é necessário chamar `SaveChanges` aqui, pois a alteração será persistida na próxima chamada de `SaveChanges`.
        }

        // Método para atualizar uma entidade existente no banco de dados.
        // O método `Update` marca a entidade como modificada e persiste as mudanças no banco.
        public void Update(T entity)
        {
            // Possíveis validações poderiam ser adicionadas aqui, como `ValidateUpdate()`.
            _context.Update(entity); // Marca a entidade como modificada.
            _context.Entry(entity).State = EntityState.Modified; // Garante que a entidade será tratada como modificada, mesmo que não tenha sido alterada.
            _context.SaveChanges(); // Persiste as alterações no banco de dados.
        }

        // Método para buscar uma entidade pelo seu ID.
        // O método `GetById` utiliza o método `Find` do contexto do Entity Framework para localizar uma entidade pelo ID.
        public T GetById(int id)
        {
            return _context.Find<T>(id); // Retorna a entidade encontrada pelo ID. Se não encontrar, retornará null.
        }

        // Método para obter todas as entidades de um tipo específico.
        // O método `GetAll` utiliza `Set<T>()` para acessar todas as entidades do tipo T e retorna uma lista delas.
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList(); // Retorna todas as entidades do tipo T como uma lista.
        }
    }
}