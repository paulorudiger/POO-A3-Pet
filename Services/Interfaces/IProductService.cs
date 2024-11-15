using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using System.Collections.Generic;

namespace POO_A4.Services.Interfaces
{
    // A interface IProductService define os métodos necessários para a manipulação de dados relacionados aos produtos.
    // Estes métodos seguem o padrão CRUD (Create, Read, Update, Delete) e utilizam DTOs para garantir que apenas os dados necessários sejam passados entre as camadas.
    public interface IProductService
    {
        // Método para adicionar um novo produto.
        // O parâmetro dto (ProductDTO) é utilizado para garantir que os dados sejam passados de forma estruturada e consistente.
        // O uso de DTOs promove a **abstração** e **encapsulamento** dos dados, desacoplando a camada de apresentação da camada de persistência.
        public Product Add(ProductDTO dto);

        // Método para atualizar as informações de um produto existente.
        // O parâmetro dto (ProductDTO) contém os dados atualizados do produto, permitindo modificar as informações sem expor diretamente a entidade.
        public Product Update(ProductDTO dto);

        // Método para excluir um produto.
        // O parâmetro id é o identificador único do produto que será removido.
        public void Delete(int id);

        // Método para buscar um produto pelo seu ID.
        // O método retorna a entidade `Product` correspondente ao ID fornecido, permitindo a recuperação das informações completas do produto.
        public Product GetById(int id);

        // Método para obter todos os produtos.
        // O método retorna uma lista de todas as entidades `Product` presentes no banco de dados, permitindo a visualização de todos os registros.
        public IEnumerable<Product> GetAll();
    }
}