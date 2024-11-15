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
    // Manter banhos e tosas
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        // Programacao para abstracao
        private readonly IAppointmentService _service;

        public AppointmentsController(PetDbContext context)
        {
            _service = new AppointmentService(context);
        }

        [HttpPost]
        public ActionResult<Appointment> Insert([FromBody] AppointmentDTO body)
        {
            try
            {
                var entity = _service.Add(body);
                return Ok(entity);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Appointment> GetById(int id)
        {
            try
            {
                var appointment = _service.GetById(id);

                return Ok(appointment);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("/getAllAppointments")]
        public ActionResult<IEnumerable<Appointment>> GetAll()
        {
            try
            {
                var appointments = _service.GetAll();
                return Ok(appointments);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Appointment> Update(int id, [FromBody] AppointmentDTO body)
        {
            try
            {
                var updatedAppointment = _service.Update(body);
                if (updatedAppointment == null)
                    return NotFound("Appointment not found");

                return Ok(updatedAppointment);
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
                Logger.Error(e.Message);
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
                // Se não achar nenhum appointment com o id informado retorna um 404
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}