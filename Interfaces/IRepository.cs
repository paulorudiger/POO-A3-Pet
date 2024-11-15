using POO_A4.Database;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace POO_A4.Interfaces
{
    // A interface IRepository<T> define a estrutura básica para operações CRUD (Create, Read, Update, Delete).
    // Esta interface será implementada por repositórios específicos, permitindo a abstração das operações de acesso aos dados.
    // O uso de generics permite que o repositório seja reutilizado para qualquer tipo de entidade (T).
    public interface IRepository<T> where T : class
    {
        // A interface define os métodos que um repositório deve implementar.
        // Esses métodos irão realizar operações sobre o banco de dados ou outra fonte de dados.

        // Método para adicionar uma entidade ao repositório.
        // O método `Add` será implementado pelos repositórios para realizar a inserção de dados.
        public void Add(T entity);

        // Método para atualizar uma entidade existente no repositório.
        // O método `Update` será implementado pelos repositórios para realizar a atualização dos dados.
        public void Update(T entity);

        // Método para deletar uma entidade do repositório.
        // O método `Delete` será implementado pelos repositórios para excluir dados.
        public void Delete(T entity);

        // Método para buscar uma entidade pelo seu ID.
        // O método `GetById` irá buscar uma entidade pelo identificador único.
        public T GetById(int id);

        // Método para buscar todas as entidades do tipo T.
        // O método `GetAll` irá retornar todas as entidades do repositório, geralmente como uma lista ou coleção.
        public IEnumerable<T> GetAll();
    }
}