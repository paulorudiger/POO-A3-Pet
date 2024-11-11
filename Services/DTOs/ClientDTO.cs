﻿using System;

namespace POO_A4.Services.DTOs
{
    public class ClientDTO
    {
        // Implementada a linha a seguir para que o exemplo de json apresentado no swagger
        // não sugira que o usuario insira um appointmentid. Isto se da pois o conrole da "Primary key"
        // será feita de forma manual no codigo, visto que, estamos utilizando database InMemory.
        [System.Text.Json.Serialization.JsonIgnore]
        public int clientid { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string adress { get; set; }

        public string phone { get; set; }
    }
}