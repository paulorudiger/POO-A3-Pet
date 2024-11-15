using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;

namespace POO_A4.Services.Mappers
{
    public class VetRecordMapper : Profile
    {
        public VetRecordMapper()
        {
            CreateMap<VetRecord, VetRecordDTO>().ReverseMap();
        }
    }
}