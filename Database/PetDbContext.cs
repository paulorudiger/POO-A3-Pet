using Microsoft.EntityFrameworkCore;
using POO_A3_Pet.Database.Models;

namespace POO_A4.Database
{
    // A classe PetDbContext é um contexto do Entity Framework que gerencia as interações entre as entidades e o banco de dados.
    // Ele herda de DbContext, fornecendo uma camada de abstração para o acesso e manipulação dos dados.
    public class PetDbContext : DbContext
    {
        // Construtores
        // O primeiro construtor é o construtor padrão, usado quando nenhuma configuração de banco de dados é fornecida.
        public PetDbContext()
        {
        }

        // O segundo construtor recebe DbContextOptions e é usado para configurar o banco de dados, como a string de conexão.
        // Ele permite que a aplicação utilize diferentes opções de configuração (por exemplo, SQL Server, SQLite, In-Memory).
        public PetDbContext(DbContextOptions<PetDbContext> options)
            : base(options)
        {
        }

        // Definir DbSets para as entidades.
        // Cada DbSet representa uma coleção de entidades no banco de dados.
        // Cada tabela do banco de dados será mapeada para uma propriedade DbSet, permitindo que as operações CRUD sejam realizadas facilmente.
        public DbSet<Appointment> Appointments { get; set; } // Representa a tabela de agendamentos (Appointments).

        public DbSet<Client> Clients { get; set; } // Representa a tabela de clientes (Clients).
        public DbSet<Pet> Pets { get; set; } // Representa a tabela de pets (Pets).
        public DbSet<Product> Products { get; set; } // Representa a tabela de produtos (Products).
        public DbSet<VetRecord> VetRecords { get; set; } // Representa a tabela de registros veterinários (VetRecords).

        // Configuração do banco de dados in-memory
        // O método OnConfiguring é chamado ao configurar o contexto. Ele permite especificar a configuração do banco de dados.
        // Se o contexto não estiver configurado, ele utiliza um banco de dados em memória (útil para testes ou desenvolvimento rápido).
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verifica se o banco de dados já foi configurado, caso contrário, configura o banco de dados em memória.
            if (!optionsBuilder.IsConfigured)
            {
                // Configura o banco de dados em memória, nomeando a base de dados como "PetDb".
                optionsBuilder.UseInMemoryDatabase("PetDb");
            }
        }
    }
}