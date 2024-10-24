using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POO_A3_Pet.Database.Models;
using POO_A4.Database;
using POO_A4.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace POO_A3_Pet.Database.Repositories
{
    public class AppointmentRepository : Repository<Appointment>
    {
        public AppointmentRepository(PetDbContext dbContext) : base(dbContext)
        {
        }

        //  public override add()
        // {
        // ValidateRemove
        // base que vai voltar para RepositoryService
        // }
    }
}