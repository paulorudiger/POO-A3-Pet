using Microsoft.AspNetCore.Mvc;
using POO_A4.Services.Interfaces;
using POO_A4.Services.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using POO_A3_Pet.Database.Models;
using POO_A4.Database;
using POO_A4.Services;
using POO_A3_Pet.Domain;

namespace POO_A4.Controllers
{
    // Controlador responsável pela gestão dos Pets (bichos). Este controlador lida com as operações CRUD para a entidade Pet.
    // A classe segue os princípios de POO, como abstração e encapsulamento, ao utilizar serviços e DTOs.
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        // A dependência de IPetService é injetada no controlador, promovendo o princípio de **injeção de dependência**.
        // Isso desacopla a lógica de negócios da camada de controle e facilita testes.
        private readonly IPetService _service;

        // O construtor do controlador recebe o contexto do banco de dados e inicializa o serviço de pets.
        // A injeção de dependência garante que o controlador se concentre apenas em gerenciar as requisições HTTP.
        public PetsController(PetDbContext context)
        {
            _service = new PetService(context); // O serviço de pets é instanciado com o contexto do banco de dados.
        }

        // Endpoint para adicionar um novo pet ao sistema.
        // O DTO PetDTO contém as informações necessárias para a criação de um pet, seguindo o padrão de **abstração**.
        [HttpPost]
        public ActionResult<Pet> Insert([FromBody] PetDTO body)
        {
            try
            {
                // A lógica de inserção é delegada ao serviço, mantendo o controlador focado em lidar com as requisições.
                var entity = _service.Add(body);
                return Ok(entity); // Retorna o pet recém-criado.
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message); // Retorna erro 400 se os dados forem inválidos.
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message); // Log de advertência em caso de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }

        // Endpoint para buscar um pet pelo ID.
        // A lógica de acesso ao pet é delegada ao serviço, que interage com o banco de dados.
        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
            try
            {
                var pet = _service.GetById(id); // Chama o método GetById do serviço para buscar o pet.
                if (pet == null)
                    return NotFound("Pet not found"); // Se o pet não for encontrado, retorna 404.

                return Ok(pet); // Retorna o pet encontrado com sucesso.
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message); // Retorna 404 se o pet não for encontrado.
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message); // Log de advertência em caso de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }

        // Endpoint para buscar todos os pets.
        // O serviço abstrai a lógica de busca, e o controlador apenas chama o serviço para obter a lista de pets.
        [HttpGet("/getAllPets")]
        public ActionResult<IEnumerable<Pet>> GetAll()
        {
            try
            {
                var pets = _service.GetAll(); // Chama o método GetAll do serviço para obter todos os pets.
                return Ok(pets); // Retorna a lista de pets encontrados.
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }

        // Endpoint para atualizar um pet existente.
        // A atualização é realizada pelo método Update do serviço, que encapsula a lógica de atualização de um pet.
        [HttpPut("{id}")]
        public ActionResult<Pet> Update(int id, [FromBody] PetDTO body)
        {
            try
            {
                var updatedPet = _service.Update(body); // Chama o método de atualização do serviço.
                if (updatedPet == null)
                    return NotFound("Pet not found"); // Se o pet não for encontrado, retorna 404.

                return Ok(updatedPet); // Retorna o pet atualizado com sucesso.
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message); // Retorna erro 400 se os dados forem inválidos.
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message); // Retorna 404 se o pet não for encontrado.
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message); // Log de advertência em caso de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }

        // Endpoint para deletar um pet pelo ID.
        // O serviço de pets é responsável por realizar a exclusão do pet no banco de dados.
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id); // Chama o método Delete do serviço para remover o pet.
                return NoContent(); // Retorna 204 No Content se a exclusão for bem-sucedida.
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message); // Retorna 404 se o pet não for encontrado.
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message); // Log de advertência em caso de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }
    }
}