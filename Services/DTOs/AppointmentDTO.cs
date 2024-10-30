using System;

namespace POO_A4.Services.DTOs
{
    public class AppointmentDTO
    {
        public int appointmentid { get; set; }

        public string observation { get; set; }

        public DateTime appointmentDate { get; set; }

        public int clientid { get; set; }

        public int petid { get; set; }

        public string productid { get; set; }
    }
}