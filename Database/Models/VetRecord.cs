using System;

namespace POO_A3_Pet.Database.Models
{
    public class VetRecord
    {
        public int vetrecordid { get; set; }

        public string vetName { get; set; }

        public int petid { get; set; }

        public string observations { get; set; }

        public DateTime appointmentDate { get; set; }
    }
}