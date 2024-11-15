using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;

namespace POO_A4.Services.Mappers
{
    // A classe VetRecordMapper herda de Profile, que é uma classe base fornecida pelo AutoMapper.
    // O AutoMapper é uma biblioteca que simplifica a conversão de objetos entre tipos diferentes, como a conversão de entidades para DTOs e vice-versa.
    public class VetRecordMapper : Profile
    {
        // O construtor da classe define o mapeamento entre a entidade VetRecord e o DTO VetRecordDTO.
        // O método CreateMap é utilizado para definir como um tipo será mapeado para outro.
        // O mapeamento é bidirecional, ou seja, a conversão pode ser feita tanto de VetRecord para VetRecordDTO quanto de VetRecordDTO para VetRecord.
        public VetRecordMapper()
        {
            CreateMap<VetRecord, VetRecordDTO>().ReverseMap();
            // CreateMap<VetRecord, VetRecordDTO> cria o mapeamento de VetRecord para VetRecordDTO.
            // ReverseMap() cria o mapeamento inverso de VetRecordDTO para VetRecord, tornando o mapeamento bidirecional.
        }
    }
}