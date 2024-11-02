using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using System.Collections.Generic;

namespace POO_A3_Pet.Services.Interfaces
{
    public interface IVetRecordService
    {
        public VetRecord Add(VetRecordDTO dto);

        public VetRecord Update(VetRecordDTO dto);

        public void Delete(int id);

        public VetRecord GetById(int id);

        public IEnumerable<VetRecord> GetAll();
    }
}