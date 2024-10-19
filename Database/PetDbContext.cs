using Microsoft.EntityFrameworkCore;
using POO_A4.Models;

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
        public DbSet<VetRecord> VetRecords { get; set; }

        // Configuração do banco de dados in-memory
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Define o banco de dados InMemory
                optionsBuilder.UseInMemoryDatabase("PetDb");
            }
        }

        // Configurações adicionais das entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade Appointment
            /*   modelBuilder.Entity<Appointment>(entity =>
               {
                   entity.HasKey(e => e.Id);
                   entity.Property(e => e.Date).IsRequired();
                   entity.HasOne(e => e.Pet)
                         .WithMany(p => p.Appointments)
                         .HasForeignKey(e => e.PetId);
                   entity.HasOne(e => e.Client)
                         .WithMany(c => c.Appointments)
                         .HasForeignKey(e => e.ClientId);
               });

               // Configuração da entidade Client
               modelBuilder.Entity<Client>(entity =>
               {
                   entity.HasKey(e => e.Id);
                   entity.Property(e => e.Name).IsRequired();
                   entity.Property(e => e.Email).HasMaxLength(100);
               });

               // Configuração da entidade Pet
               modelBuilder.Entity<Pet>(entity =>
               {
                   entity.HasKey(e => e.Id);
                   entity.Property(e => e.Name).IsRequired();
                   entity.HasOne(e => e.Client)
                         .WithMany(c => c.Pets)
                         .HasForeignKey(e => e.ClientId);
               });

               // Configuração da entidade VetRecord
               modelBuilder.Entity<VetRecord>(entity =>
               {
                   entity.HasKey(e => e.Id);
                   entity.Property(e => e.Description).IsRequired();
                   entity.HasOne(e => e.Pet)
                         .WithMany(p => p.VetRecords)
                         .HasForeignKey(e => e.PetId);
               });
            */
        }
    }
}