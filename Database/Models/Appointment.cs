using System;

namespace POO_A3_Pet.Database.Models
{
    public class Appointment
    {
        public int appointmentid { get; set; }

        public string observation { get; set; }

        public DateTime appointmentDate { get; set; }

        public int clientid { get; set; }

        public int petid { get; set; }

        // nao pode ter um produto do tipo produto
        public int productid { get; set; }
    }
}