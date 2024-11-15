using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using System.Collections.Generic;

namespace POO_A4.Services.Interfaces
{
    // A interface IPetService define os métodos necessários para a manipulação de dados relacionados aos pets.
    // Esses métodos seguem o padrão CRUD (Create, Read, Update, Delete) e utilizam DTOs para garantir que apenas os dados necessários sejam transferidos.
    public interface IPetService
    {
        // Método para adicionar um novo pet.
        // O parâmetro dto (PetDTO) é utilizado para garantir que os dados fornecidos estejam estruturados corretamente antes de serem adicionados.
        // O uso de DTOs ajuda a desacoplar a camada de apresentação da camada de persistência de dados.
        public Pet Add(PetDTO dto);

        // Método para atualizar as informações de um pet existente.
        // O parâmetro dto (PetDTO) contém os dados atualizados do pet, permitindo modificar as informações sem expor diretamente a entidade.
        public Pet Update(PetDTO dto);

        // Método para excluir um pet.
        // O parâmetro id é o identificador único do pet que será excluído. O método remove o pet do banco de dados.
        public void Delete(int id);

        // Método para buscar um pet pelo seu ID.
        // O método retorna a entidade `Pet` correspondente ao ID fornecido, permitindo a recuperação das informações completas do pet.
        public Pet GetById(int id);

        // Método para obter todos os pets.
        // O método retorna uma lista de todas as entidades `Pet`, permitindo a recuperação de todos os registros de pets do banco de dados.
        public IEnumerable<Pet> GetAll();
    }
}