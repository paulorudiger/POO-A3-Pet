using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Domain.Enums;
using POO_A4.Database;
using System;
using System.Linq;

public static class DbInitializer
{
    // Método Seed inicializa os dados do banco de dados se as tabelas estiverem vazias.
    // Este método é chamado em program.cs para fornecer dados de exemplo.
    public static void Seed(PetDbContext context)
    {
        // Verifica se já existem registros na tabela de Appointments para evitar duplicação de dados.
        // O método Any() verifica se existe algum registro na tabela. Se não existir, os dados são inseridos.
        if (!context.Appointments.Any())
        {
            // Adiciona registros de exemplo na tabela de Appointments (Agendamentos).
            context.Appointments.AddRange(
                new Appointment
                {
                    appointmentid = 1,
                    observation = "Regular check-up",
                    appointmentDate = DateTime.Now.AddDays(1), // Define a data do agendamento para 1 dia após a execução.
                    clientid = 1,
                    petid = 1,
                    productid = 1
                },
                new Appointment
                {
                    appointmentid = 2,
                    observation = "Vaccination",
                    appointmentDate = DateTime.Now.AddDays(3), // Define a data do agendamento para 3 dias após a execução.
                    clientid = 2,
                    petid = 2,
                    productid = 1
                }
            );
        }

        // Verifica se já existem registros na tabela de Clients (Clientes).
        if (!context.Clients.Any())
        {
            // Adiciona registros de exemplo na tabela de Clients.
            context.Clients.AddRange(
                new Client
                {
                    clientid = 1,
                    name = "John Doe",
                    email = "johndoe@email.com",
                    adress = "123 Main St",
                    phone = "123-456-7890"
                },
                new Client
                {
                    clientid = 2,
                    name = "Jane Smith",
                    email = "janesmith@email.com",
                    adress = "456 Oak St",
                    phone = "987-654-3210"
                }
            );
        }

        // Verifica se já existem registros na tabela de Pets (Bichos).
        if (!context.Pets.Any())
        {
            // Adiciona registros de exemplo na tabela de Pets.
            context.Pets.AddRange(
                new Pet
                {
                    petid = 1,
                    name = "Buddy",
                    description = "Golden Retriever",
                    breed = "Golden Retriever",
                    weight = "30kg"
                },
                new Pet
                {
                    petid = 2,
                    name = "Mittens",
                    description = "Cat",
                    breed = "Persian",
                    weight = "5kg"
                }
            );
        }

        // Verifica se já existem registros na tabela de Products (Produtos).
        if (!context.Products.Any())
        {
            // Adiciona registros de exemplo na tabela de Products.
            context.Products.AddRange(
                new Product
                {
                    productid = 1,
                    productName = "Shampoo",
                    description = "Shampoo for dogs",
                    price = 10.99m,
                    productType = ProductType.Service // Define o tipo do produto como Serviço.
                },
                new Product
                {
                    productid = 2,
                    productName = "Dog Toy",
                    description = "Chew toy for pets",
                    price = 5.99m,
                    productType = ProductType.Product // Define o tipo do produto como Produto físico.
                }
            );
        }

        // Verifica se já existem registros na tabela de VetRecords (Registros Veterinários).
        if (!context.VetRecords.Any())
        {
            // Adiciona registros de exemplo na tabela de VetRecords.
            context.VetRecords.AddRange(
                new VetRecord
                {
                    vetrecordid = 1,
                    vetName = "Dr. Smith",
                    petid = 1,
                    observations = "Healthy, annual check-up.",
                    appointmentDate = DateTime.Now.AddDays(1)
                },
                new VetRecord
                {
                    vetrecordid = 2,
                    vetName = "Dr. John",
                    petid = 2,
                    observations = "Healthy, routine check-up.",
                    appointmentDate = DateTime.Now.AddDays(2)
                }
            );
        }

        // Após adicionar todos os dados necessários, as mudanças são salvas no banco de dados.
        context.SaveChanges(); // Persiste os dados no banco.
    }
}