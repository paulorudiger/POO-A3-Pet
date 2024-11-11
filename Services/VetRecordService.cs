using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Database.Repositories;
using POO_A3_Pet.Services.Interfaces;
using POO_A4.Database;
using POO_A4.Interfaces;
using POO_A4.Services.DTOs;
using System.Collections.Generic;

namespace POO_A4.Services
{
    public class VetRecordService : IVetRecordService
    {
        private readonly IRepository<VetRecord> _repository;
        //   private readonly AppointmentParser _parser; TODO: fazer o parser desta classe

        private VetRecordService(PetDbContext dbcontext)
        {
            _repository = new Repository<VetRecord>(dbcontext);
        }

        public VetRecord Add(VetRecordDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<VetRecord> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public VetRecord GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public VetRecord Update(VetRecordDTO dto)
        {
            throw new System.NotImplementedException();
        }
    }
}