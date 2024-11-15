using AutoMapper;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using POO_A4.Services.Mappers;

namespace POO_A4.Services.Parsers
{
    // A classe ClientParser é responsável por realizar a conversão de um ClientDTO para a entidade Client.
    // Ela utiliza o AutoMapper para facilitar o processo de transformação de objetos de tipos diferentes.
    public class ClientParser
    {
        // A interface IMapper é usada para mapear objetos entre tipos diferentes (neste caso, entre ClientDTO e Client).
        private readonly IMapper _mapper;

        // O construtor configura o AutoMapper, criando uma instância do IMapper.
        // O perfil de mapeamento `ClientMapper` é adicionado para definir como os tipos Client e ClientDTO serão convertidos.
        public ClientParser()
        {
            // Cria a configuração do AutoMapper, registrando o perfil de mapeamento do ClientMapper.
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClientMapper>(); // Adiciona o perfil de mapeamento específico para Client.
            });
            // Cria a instância do IMapper usando a configuração definida.
            _mapper = config.CreateMapper();
        }

        // Método ParseClient converte um objeto ClientDTO para a entidade Client.
        // O método utiliza o AutoMapper para realizar o mapeamento entre os tipos.
        public Client ParseClient(ClientDTO dto)
        {
            // Utiliza o AutoMapper para converter o DTO (ClientDTO) em uma entidade (Client).
            return _mapper.Map<Client>(dto); // Retorna a entidade mapeada.
        }
    }
}