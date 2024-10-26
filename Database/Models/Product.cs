using POO_A3_Pet.Domain.Enums;
using System;

namespace POO_A3_Pet.Database.Models
{
    public class Product
    {
        public int productid { get; set; }

        // ex: banho, tosa, banhotosa, veterinario, OU ossobrinquedo
        public string productName { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        public ProductType productType { get; set; }
    }
}