using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Domain.Enums;
using POO_A4.Database;
using System;
using System.Linq;

public static class DbInitializer
{
    public static void Seed(PetDbContext context)
    {
        // Verifica se os dados já existem para evitar duplicação
        if (!context.Appointments.Any())
        {
            // Adiciona registros na tabela de Appointments
            context.Appointments.AddRange(
                new Appointment
                {
                    appointmentid = 1,
                    observation = "Regular check-up",
                    appointmentDate = DateTime.Now.AddDays(1),
                    clientid = 1,
                    petid = 1,
                    productid = 1
                },
                new Appointment
                {
                    appointmentid = 2,
                    observation = "Vaccination",
                    appointmentDate = DateTime.Now.AddDays(3),
                    clientid = 2,
                    petid = 2,
                    productid = 1
                }
            );
        }

        if (!context.Clients.Any())
        {
            // Adiciona registros na tabela de Clients
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

        if (!context.Pets.Any())
        {
            // Adiciona registros na tabela de Pets
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

        if (!context.Products.Any())
        {
            // Adiciona registros na tabela de Products
            context.Products.AddRange(
                new Product
                {
                    productid = 1,
                    productName = "Shampoo",
                    description = "Shampoo for dogs",
                    price = 10.99m,
                    productType = ProductType.Service
                },
                new Product
                {
                    productid = 2,
                    productName = "Dog Toy",
                    description = "Chew toy for pets",
                    price = 5.99m,
                    productType = ProductType.Product
                }
            );
        }

        if (!context.VetRecords.Any())
        {
            // Adiciona registros na tabela de VetRecords
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

        // Salva as alterações no banco de dados
        context.SaveChanges();
    }
}