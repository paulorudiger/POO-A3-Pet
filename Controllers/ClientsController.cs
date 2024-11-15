using Microsoft.AspNetCore.Mvc;
using POO_A4.Services.Interfaces;
using POO_A4.Services.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Services;
using POO_A4.Database;
using POO_A4.Services;
using POO_A3_Pet.Domain;

namespace POO_A4.Controllers
{
    // Controlador responsável pela gestão dos Clientes.
    // Cada endpoint lida com as operações relacionadas aos clientes da aplicação.
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        // Definindo o serviço de clientes, usando a interface IClientService para abstração.
        private readonly IClientService _service;

        // O construtor recebe um contexto e cria a instância do serviço de clientes.
        // Isso é um exemplo de **injeção de dependência**, que permite um código mais desacoplado e testável.
        public ClientsController(PetDbContext context)
        {
            _service = new ClientService(context); // Instancia o serviço de clientes, passando o contexto do banco.
        }

        // Endpoint para adicionar um novo cliente.
        // O método `Insert` recebe um DTO com as informações do cliente e utiliza o serviço de clientes para realizar a inserção.
        // Essa abordagem promove a **abstração** da lógica de negócio, delegando o processamento para o serviço.
        [HttpPost]
        public ActionResult<Client> Insert([FromBody] ClientDTO body)
        {
            try
            {
                // Chama o método Add do serviço, passando o DTO para adicionar o cliente.
                var entity = _service.Add(body);
                return Ok(entity); // Retorna o cliente criado com sucesso.
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message); // Log de advertência em caso de erro.
                return StatusCode(500, e.Message); // Retorna erro interno no servidor em caso de falha inesperada.
            }
        }

        // Endpoint para buscar um cliente pelo ID.
        // A abstração de acesso aos dados é realizada através do serviço, que utiliza a camada de persistência.
        [HttpGet("{id}")]
        public ActionResult<Client> GetById(int id)
        {
            try
            {
                var client = _service.GetById(id); // Chama o método GetById do serviço para obter o cliente.
                if (client == null)
                    return NotFound("Client not found"); // Se o cliente não for encontrado, retorna 404 Not Found.

                return Ok(client); // Retorna o cliente encontrado com sucesso.
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message); // Se o cliente não for encontrado, retorna 404 Not Found.
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message); // Log de advertência em caso de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro interno no servidor.
            }
        }

        // Endpoint para buscar todos os clientes.
        // O serviço abstrai a lógica de obtenção dos dados e facilita a manutenção e testes.
        [HttpGet("/getAllClients")]
        public ActionResult<IEnumerable<Client>> GetAll()
        {
            try
            {
                var clients = _service.GetAll(); // Chama o método GetAll do serviço para obter todos os clientes.
                return Ok(clients); // Retorna a lista de clientes encontrados com sucesso.
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); // Retorna erro interno no servidor em caso de falha inesperada.
            }
        }

        // Endpoint para atualizar um cliente existente.
        // O método `Update` permite a alteração das informações do cliente. A lógica de atualização é delegada ao serviço.
        [HttpPut("{id}")]
        public ActionResult<Client> Update(int id, [FromBody] ClientDTO body)
        {
            try
            {
                var updatedClient = _service.Update(body); // Chama o método Update do serviço, passando o DTO atualizado.
                if (updatedClient == null)
                    return NotFound("Client not found"); // Se o cliente não for encontrado, retorna 404 Not Found.

                return Ok(updatedClient); // Retorna o cliente atualizado com sucesso.
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message); // Se os dados forem inválidos, retorna erro 400 Bad Request.
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message); // Se o cliente não for encontrado, retorna 404 Not Found.
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message); // Log de advertência em caso de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro interno no servidor.
            }
        }

        // Endpoint para deletar um cliente pelo ID.
        // O serviço é responsável por lidar com a exclusão do cliente.
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id); // Chama o método Delete do serviço para remover o cliente.
                return NoContent(); // Retorna 204 No Content se a exclusão for bem-sucedida.
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message); // Retorna 404 se o cliente não for encontrado para exclusão.
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message); // Log de advertência em caso de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro interno no servidor.
            }
        }
    }
}