using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using System.Collections.Generic;

namespace POO_A4.Services.Interfaces
{
    public interface IPetService
    {
        // CRUD com parametro DTO

        public Pet Add(PetDTO dto);

        public Pet Update(PetDTO dto);

        public void Delete(int id);

        public Pet GetById(int id);

        public IEnumerable<Pet> GetAll();
    }
}