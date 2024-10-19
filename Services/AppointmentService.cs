using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POO_A4.Database;
using POO_A4.Interfaces;
using POO_A4.Models;

namespace POO_A4.Services
{
    public class AppointmentService : IRepository<Appointment>
    {

        private readonly PetDbContext _dbcontext;
        private readonly IMapper _mapper;

        public AppointmentService(PetDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }


    }
}
