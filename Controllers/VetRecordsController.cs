using Microsoft.AspNetCore.Mvc;
using POO_A4.Services.Interfaces;
using POO_A4.Services.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using POO_A3_Pet.Domain;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Services.Interfaces;
using POO_A4.Database;
using POO_A4.Services;

namespace POO_A4.Controllers
{
    // Controlador responsável pela gestão dos registros veterinários (VetRecord).
    // Cada endpoint lida com operações CRUD para a entidade VetRecord.
    // A classe segue os princípios de POO, como abstração e encapsulamento, ao utilizar serviços e DTOs.
    [Route("api/[controller]")]
    [ApiController]
    public class VetRecordsController : ControllerBase
    {
        // A dependência de IVetRecordService é injetada no controlador, promovendo o princípio de **injeção de dependência**.
        // Isso desacopla a lógica de negócios da camada de controle e facilita testes unitários.
        private readonly IVetRecordService _service;

        // O construtor do controlador recebe o contexto do banco de dados e cria uma instância do serviço de registros veterinários.
        // A injeção de dependência garante que o controlador se concentre apenas em gerenciar as requisições HTTP.
        public VetRecordsController(PetDbContext context)
        {
            _service = new VetRecordService(context); // O serviço de registros veterinários é instanciado com o contexto do banco de dados.
        }

        // Endpoint para adicionar um novo registro veterinário.
        // O DTO VetRecordDTO contém as informações necessárias para a criação de um registro veterinário, promovendo o padrão de **abstração**.
        [HttpPost]
        public ActionResult<VetRecord> Insert([FromBody] VetRecordDTO body)
        {
            try
            {
                // A lógica de inserção é delegada ao serviço, mantendo o controlador focado em lidar com as requisições HTTP.
                var entity = _service.Add(body);
                return Ok(entity); // Retorna o registro veterinário recém-criado.
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

        // Endpoint para buscar um registro veterinário pelo ID.
        // A lógica de acesso ao registro veterinário é delegada ao serviço, que interage com o banco de dados.
        [HttpGet("{id}")]
        public ActionResult<VetRecord> GetById(int id)
        {
            try
            {
                var vetRecord = _service.GetById(id); // Chama o método GetById do serviço para buscar o registro veterinário.
                if (vetRecord == null)
                    return NotFound("Vet record not found"); // Se o registro não for encontrado, retorna 404.

                return Ok(vetRecord); // Retorna o registro veterinário encontrado com sucesso.
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message); // Retorna 404 se o registro veterinário não for encontrado.
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message); // Log de advertência em caso de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }

        // Endpoint para buscar todos os registros veterinários.
        // O serviço abstrai a lógica de busca, e o controlador apenas chama o serviço para obter a lista de registros veterinários.
        [HttpGet("/getAllVetRecords")]
        public ActionResult<IEnumerable<VetRecord>> GetAll()
        {
            try
            {
                var vetRecords = _service.GetAll(); // Chama o método GetAll do serviço para obter todos os registros veterinários.
                return Ok(vetRecords); // Retorna a lista de registros veterinários encontrados.
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }

        // Endpoint para atualizar um registro veterinário existente.
        // A atualização é realizada pelo método Update do serviço, que encapsula a lógica de atualização de um registro veterinário.
        [HttpPut("{id}")]
        public ActionResult<VetRecord> Update(int id, [FromBody] VetRecordDTO body)
        {
            try
            {
                var updatedVetRecord = _service.Update(body); // Chama o método de atualização do serviço.
                if (updatedVetRecord == null)
                    return NotFound("Vet record not found"); // Se o registro não for encontrado, retorna 404.

                return Ok(updatedVetRecord); // Retorna o registro veterinário atualizado com sucesso.
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message); // Retorna erro 400 se os dados forem inválidos.
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message); // Retorna 404 se o registro veterinário não for encontrado.
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message); // Log de advertência em caso de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }

        // Endpoint para deletar um registro veterinário pelo ID.
        // O serviço de registros veterinários é responsável por realizar a exclusão do registro.
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id); // Chama o método Delete do serviço para remover o registro veterinário.
                return NoContent(); // Retorna 204 No Content se a exclusão for bem-sucedida.
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message); // Retorna 404 se o registro veterinário não for encontrado.
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message); // Log de advertência em caso de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro 500 em caso de falha interna no servidor.
            }
        }
    }
}