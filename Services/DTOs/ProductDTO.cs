using POO_A3_Pet.Domain.Enums;

namespace POO_A4.Services.DTOs
{
    public class ProductDTO
    {
        public int productid { get; set; }

        public string productName { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        public ProductType productType { get; set; }
    }
}