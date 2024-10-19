using AutoMapper;
using POO_A4.Database;
using POO_A4.Interfaces;
using POO_A4.Models;
using System.Collections.Generic;

namespace POO_A4.Services
{
    public class VetRecordService : IRepository<VetRecord>
    {
        private readonly PetDbContext _dbcontext;
        private readonly IMapper _mapper;

        private VetRecordService(PetDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
    }
}