using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using POO_A4.Services.Mappers;

namespace POO_A4.Services.Parsers
{
    public class VetRecordParser
    {
        private readonly IMapper _mapper;

        public VetRecordParser()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<VetRecordMapper>();
            });
            _mapper = config.CreateMapper();
        }

        public VetRecord ParseVetRecord(VetRecordDTO dto)
        {
            // Utiliza o AutoMapper para converter o DTO para a entidade
            return _mapper.Map<VetRecord>(dto);
        }
    }
}