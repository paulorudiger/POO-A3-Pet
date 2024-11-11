using System;

namespace POO_A4.Services.DTOs
{
    public class AppointmentDTO
    {
        // Implementada a linha a seguir para que o exemplo de json apresentado no swagger
        // não sugira que o usuario insira um appointmentid. Isto se da pois o conrole da "Primary key"
        // será feita de forma manual no codigo, visto que, estamos utilizando database InMemory.
        [System.Text.Json.Serialization.JsonIgnore]
        public int appointmentid { get; set; }

        public string observation { get; set; }

        public DateTime appointmentDate { get; set; }

        public int clientid { get; set; }

        public int petid { get; set; }

        public int productid { get; set; }
    }
}