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
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        // Programacao para abstracao
        private readonly IClientService _service;

        public ClientsController(PetDbContext context)
        {
            _service = new ClientService(context);
        }

        [HttpPost]
        public ActionResult<Client> Insert([FromBody] ClientDTO body)
        {
            try
            {
                var entity = _service.Add(body);
                return Ok(entity);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetById(int id)
        {
            try
            {
                var client = _service.GetById(id);
                if (client == null)
                    return NotFound("Client not found");

                return Ok(client);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("/getAllClients")]
        public ActionResult<IEnumerable<Client>> GetAll()
        {
            try
            {
                var clients = _service.GetAll();
                return Ok(clients);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Client> Update(int id, [FromBody] ClientDTO body)
        {
            try
            {
                var updatedClient = _service.Update(body);
                if (updatedClient == null)
                    return NotFound("Client not found");

                return Ok(updatedClient);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Logger.Warn(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}