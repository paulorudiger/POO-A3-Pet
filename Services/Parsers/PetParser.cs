using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using POO_A4.Services.Mappers;

namespace POO_A4.Services.Parsers
{
    // A classe PetParser é responsável por realizar a conversão de um PetDTO para a entidade Pet.
    // Ela utiliza o AutoMapper para facilitar o processo de transformação de objetos de tipos diferentes.
    public class PetParser
    {
        // A interface IMapper é usada para mapear objetos entre tipos diferentes (neste caso, entre PetDTO e Pet).
        private readonly IMapper _mapper;

        // O construtor configura o AutoMapper, criando uma instância do IMapper.
        // O perfil de mapeamento `PetMapper` é adicionado para definir como os tipos Pet e PetDTO serão convertidos.
        public PetParser()
        {
            // Cria a configuração do AutoMapper, registrando o perfil de mapeamento do PetMapper.
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PetMapper>(); // Adiciona o perfil de mapeamento específico para Pet.
            });
            // Cria a instância do IMapper usando a configuração definida.
            _mapper = config.CreateMapper();
        }

        // Método ParsePet converte um objeto PetDTO para a entidade Pet.
        // O método utiliza o AutoMapper para realizar o mapeamento entre os tipos.
        public Pet ParsePet(PetDTO dto)
        {
            // Utiliza o AutoMapper para converter o DTO (PetDTO) em uma entidade (Pet).
            return _mapper.Map<Pet>(dto); // Retorna a entidade mapeada.
        }
    }
}