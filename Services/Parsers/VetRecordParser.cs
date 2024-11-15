using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using POO_A4.Services.Mappers;

namespace POO_A4.Services.Parsers
{
    // A classe VetRecordParser é responsável por realizar a conversão de um VetRecordDTO para a entidade VetRecord.
    // Ela utiliza o AutoMapper para facilitar o processo de transformação de objetos de tipos diferentes.
    public class VetRecordParser
    {
        // A interface IMapper é usada para mapear objetos entre tipos diferentes (neste caso, entre VetRecordDTO e VetRecord).
        private readonly IMapper _mapper;

        // O construtor configura o AutoMapper, criando uma instância do IMapper.
        // O perfil de mapeamento `VetRecordMapper` é adicionado para definir como os tipos VetRecord e VetRecordDTO serão convertidos.
        public VetRecordParser()
        {
            // Cria a configuração do AutoMapper, registrando o perfil de mapeamento do VetRecordMapper.
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<VetRecordMapper>(); // Adiciona o perfil de mapeamento específico para VetRecord.
            });
            // Cria a instância do IMapper usando a configuração definida.
            _mapper = config.CreateMapper();
        }

        // Método ParseVetRecord converte um objeto VetRecordDTO para a entidade VetRecord.
        // O método utiliza o AutoMapper para realizar o mapeamento entre os tipos.
        public VetRecord ParseVetRecord(VetRecordDTO dto)
        {
            // Utiliza o AutoMapper para converter o DTO (VetRecordDTO) em uma entidade (VetRecord).
            return _mapper.Map<VetRecord>(dto); // Retorna a entidade mapeada.
        }
    }
}