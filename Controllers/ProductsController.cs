using Microsoft.AspNetCore.Mvc;
using POO_A4.Services.Interfaces;
using POO_A4.Services.DTOs;
using System;
using System.Collections.Generic;

namespace POO_A4.Controllers
{
    // Controlador responsável pela gestão dos produtos. Cada endpoint lida com operações CRUD para a entidade Product.
    // A classe segue os princípios de POO, como abstração e encapsulamento, ao utilizar serviços e DTOs.
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // A dependência de IProductService é injetada no controlador, promovendo o princípio de **injeção de dependência**.
        // Isso desacopla a lógica de negócios da camada de controle e facilita testes unitários.
        private readonly IProductService _service;

        // O construtor do controlador recebe a interface IProductService, permitindo o uso de qualquer implementação do serviço.
        // A injeção de dependência garante que o controlador se concentre apenas em gerenciar as requisições HTTP.
        public ProductsController(IProductService service)
        {
            _service = service; // O serviço de produtos é injetado via construtor.
        }

        // Endpoint para adicionar um novo produto.
        // O DTO ProductDTO contém as informações necessárias para a criação de um produto, seguindo o padrão de **abstração**.
        [HttpPost]
        public ActionResult<ProductDTO> Create([FromBody] ProductDTO dto)
        {
            try
            {
                // A lógica de inserção é delegada ao serviço, mantendo o controlador focado em lidar com as requisições HTTP.
                var createdProduct = _service.Add(dto);
                return Ok(createdProduct); // Retorna o produto recém-criado.
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }

        // Endpoint para buscar um produto pelo ID.
        // A lógica de acesso ao produto é delegada ao serviço, que interage com o banco de dados.
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetById(int id)
        {
            try
            {
                var product = _service.GetById(id); // Chama o método GetById do serviço para buscar o produto.
                return Ok(product); // Retorna o produto encontrado com sucesso.
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }

        // Endpoint para buscar todos os produtos.
        // O serviço abstrai a lógica de busca, e o controlador apenas chama o serviço para obter a lista de produtos.
        [HttpGet("getAllProducts")]
        public ActionResult<IEnumerable<ProductDTO>> GetAll()
        {
            try
            {
                var products = _service.GetAll(); // Chama o método GetAll do serviço para obter todos os produtos.
                return Ok(products); // Retorna a lista de produtos encontrados.
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }

        // Endpoint para atualizar um produto existente.
        // A atualização é realizada pelo método Update do serviço, que encapsula a lógica de atualização de um produto.
        [HttpPut("{id}")]
        public ActionResult<ProductDTO> Update(int id, [FromBody] ProductDTO dto)
        {
            try
            {
                var updatedProduct = _service.Update(dto); // Chama o método de atualização do serviço.
                return Ok(updatedProduct); // Retorna o produto atualizado com sucesso.
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }

        // Endpoint para deletar um produto pelo ID.
        // O serviço de produtos é responsável por realizar a exclusão do produto.
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id); // Chama o método Delete do serviço para remover o produto.
                return NoContent(); // Retorna 204 No Content se a exclusão for bem-sucedida.
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }
    }
}