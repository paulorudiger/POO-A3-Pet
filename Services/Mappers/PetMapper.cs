using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;

namespace POO_A4.Services.Mappers
{
    public class PetMapper : Profile
    {
        public PetMapper()
        {
            CreateMap<Pet, PetDTO>().ReverseMap();
        }
    }
}