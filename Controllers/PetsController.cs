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
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _service;

        public PetsController(PetDbContext context)
        {
            _service = new PetService(context);
        }

        [HttpPost]
        public ActionResult<Pet> Insert([FromBody] PetDTO body)
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
        public ActionResult<Pet> GetById(int id)
        {
            try
            {
                var pet = _service.GetById(id);
                if (pet == null)
                    return NotFound("Pet not found");

                return Ok(pet);
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

        [HttpGet("/getAllPets")]
        public ActionResult<IEnumerable<Pet>> GetAll()
        {
            try
            {
                var pets = _service.GetAll();
                return Ok(pets);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Update(int id, [FromBody] PetDTO body)
        {
            try
            {
                var updatedPet = _service.Update(body);
                if (updatedPet == null)
                    return NotFound("Pet not found");

                return Ok(updatedPet);
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