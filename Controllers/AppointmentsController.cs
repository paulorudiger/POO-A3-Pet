using Microsoft.AspNetCore.Mvc;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Domain;
using POO_A3_Pet.Services;
using POO_A3_Pet.Services.Interfaces;
using POO_A4.Database;
using POO_A4.Services.DTOs;
using System;
using System.Collections.Generic;
using System.IO;

namespace POO_A4.Controllers
{
    // Definindo o controlador de Appointment, responsável por gerenciar os endpoints da API relacionados a agendamentos
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        // A dependência de IAppointmentService é injetada no controlador através do construtor,
        // promovendo o princípio da injeção de dependência, que facilita o desacoplamento de componentes.
        private readonly IAppointmentService _service;

        // O construtor utiliza injeção de dependência para inicializar o serviço de agendamentos.
        // Isso promove a separação de preocupações e a aderência ao princípio da inversão de controle.
        public AppointmentsController(PetDbContext context)
        {
            _service = new AppointmentService(context); // Instancia o serviço de agendamentos com o contexto do banco de dados.
        }

        // Endpoint para adicionar um novo agendamento.
        // A abstração é feita através da interface IAppointmentService, permitindo que a lógica de inserção
        // seja tratada em um serviço separado, aderindo ao princípio da responsabilidade única.
        [HttpPost]
        public ActionResult<Appointment> Insert([FromBody] AppointmentDTO body)
        {
            try
            {
                // Chama o método Add do serviço, passando o DTO com os dados do agendamento.
                var entity = _service.Add(body);
                return Ok(entity); // Retorna a resposta de sucesso com o objeto criado.
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message); // Erro de operação inválida, retorna bad request.
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message); // Erro de dados inválidos, retorna bad request.
            }
            catch (Exception e)
            {
                Logger.Error(e.Message); // Log de erros não tratados.
                return StatusCode(500, e.Message); // Retorna erro interno no servidor.
            }
        }

        // Endpoint para obter um agendamento pelo ID.
        // O método de busca é abstraído no serviço IAppointmentService.
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetById(int id)
        {
            try
            {
                var appointment = _service.GetById(id); // Chama o método GetById do serviço.
                return Ok(appointment); // Retorna o agendamento se encontrado.
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message); // Retorna 404 se o agendamento não for encontrado.
            }
            catch (Exception e)
            {
                Logger.Error(e.Message); // Log de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro interno no servidor.
            }
        }

        // Endpoint para obter todos os agendamentos.
        // Utiliza o método GetAll do serviço, que abstrai a lógica de busca.
        [HttpGet("/getAllAppointments")]
        public ActionResult<IEnumerable<Appointment>> GetAll()
        {
            try
            {
                var appointments = _service.GetAll(); // Chama o método GetAll do serviço.
                return Ok(appointments); // Retorna todos os agendamentos.
            }
            catch (Exception e)
            {
                Logger.Error(e.Message); // Log de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro interno no servidor.
            }
        }

        // Endpoint para atualizar um agendamento existente.
        // A atualização é realizada por meio da abstração do serviço, o que segue o princípio de baixo acoplamento.
        [HttpPut("{id}")]
        public ActionResult<Appointment> Update(int id, [FromBody] AppointmentDTO body)
        {
            try
            {
                var updatedAppointment = _service.Update(body); // Chama o método de atualização do serviço.
                if (updatedAppointment == null)
                    return NotFound("Appointment not found"); // Retorna 404 se o agendamento não for encontrado para atualização.

                return Ok(updatedAppointment); // Retorna o agendamento atualizado.
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message); // Retorna bad request se houver erro nos dados fornecidos.
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message); // Retorna 404 se o agendamento não for encontrado.
            }
            catch (Exception e)
            {
                Logger.Error(e.Message); // Log de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro interno no servidor.
            }
        }

        // Endpoint para deletar um agendamento pelo ID.
        // A exclusão é feita pelo serviço, garantindo que a lógica de remoção esteja centralizada.
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id); // Chama o método de exclusão do serviço.

                return NoContent(); // Retorna sucesso sem conteúdo (204 No Content).
            }
            catch (KeyNotFoundException e)
            {
                // Se o agendamento não for encontrado, retorna 404 (não encontrado).
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message); // Log de erro inesperado.
                return StatusCode(500, e.Message); // Retorna erro interno no servidor.
            }
        }
    }
}