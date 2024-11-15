using Microsoft.EntityFrameworkCore;
using POO_A3_Pet.Database.Models;

namespace POO_A4.Database
{
    public class PetDbContext : DbContext
    {
        // Construtores
        public PetDbContext()
        {
        }

        public PetDbContext(DbContextOptions<PetDbContext> options)
            : base(options)
        {
        }

        // Definir DbSets para as entidades
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<VetRecord> VetRecords { get; set; }

        // Configuração do banco de dados in-memory
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("PetDb");
            }
        }
    }
}