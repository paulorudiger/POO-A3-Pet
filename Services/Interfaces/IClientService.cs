using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using System.Collections.Generic;

namespace POO_A4.Services.Interfaces
{
    public interface IClientService
    {
        // CRUD com parametro DTO

        public Client Add(ClientDTO dto);

        public Client Update(ClientDTO dto);

        public void Delete(int id);

        public Client GetById(int id);

        public IEnumerable<Client> GetAll();
    }
}