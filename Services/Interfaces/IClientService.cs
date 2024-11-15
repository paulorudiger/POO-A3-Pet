using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using System.Collections.Generic;

namespace POO_A4.Services.Interfaces
{
    // A interface IClientService define os métodos necessários para manipulação de clientes.
    // Esses métodos seguem o padrão CRUD (Create, Read, Update, Delete) e utilizam DTOs para garantir que apenas dados necessários sejam transferidos.
    public interface IClientService
    {
        // Método para adicionar um novo cliente.
        // O parâmetro dto (ClientDTO) é utilizado para garantir que os dados sejam fornecidos de forma estruturada e segura.
        // O uso de DTOs ajuda a desacoplar a camada de apresentação da camada de persistência de dados.
        public Client Add(ClientDTO dto);

        // Método para atualizar os dados de um cliente existente.
        // O parâmetro dto (ClientDTO) fornece os dados atualizados para o cliente, permitindo a modificação sem expor diretamente a entidade.
        public Client Update(ClientDTO dto);

        // Método para excluir um cliente.
        // O método recebe um ID e realiza a exclusão do cliente correspondente. Este ID é único e identifica de forma precisa o cliente.
        public void Delete(int id);

        // Método para buscar um cliente pelo seu ID.
        // O método retorna a entidade `Client` correspondente ao ID fornecido, permitindo a recuperação dos dados completos do cliente.
        public Client GetById(int id);

        // Método para buscar todos os clientes.
        // O método retorna uma lista de todas as entidades `Client` presentes no banco de dados, permitindo a visualização de todos os registros.
        public IEnumerable<Client> GetAll();
    }
}