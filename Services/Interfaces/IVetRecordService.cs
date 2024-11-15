using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using System.Collections.Generic;

namespace POO_A3_Pet.Services.Interfaces
{
    // A interface IVetRecordService define os métodos necessários para a manipulação de dados relacionados aos registros veterinários.
    // Estes métodos seguem o padrão CRUD (Create, Read, Update, Delete) e utilizam DTOs para garantir que apenas os dados necessários sejam passados entre as camadas.
    public interface IVetRecordService
    {
        // Método para adicionar um novo registro veterinário.
        // O parâmetro dto (VetRecordDTO) é utilizado para garantir que os dados do registro sejam fornecidos de forma estruturada e consistente.
        // Isso ajuda a desacoplar a camada de apresentação da camada de persistência de dados.
        public VetRecord Add(VetRecordDTO dto);

        // Método para atualizar um registro veterinário existente.
        // O parâmetro dto (VetRecordDTO) contém os dados atualizados do registro veterinário, permitindo a modificação sem expor diretamente a entidade.
        public VetRecord Update(VetRecordDTO dto);

        // Método para excluir um registro veterinário.
        // O parâmetro id é o identificador único do registro que será removido.
        public void Delete(int id);

        // Método para buscar um registro veterinário pelo seu ID.
        // O método retorna a entidade `VetRecord` correspondente ao ID fornecido, permitindo a recuperação das informações completas do registro.
        public VetRecord GetById(int id);

        // Método para obter todos os registros veterinários.
        // O método retorna uma lista de todas as entidades `VetRecord` presentes no banco de dados.
        public IEnumerable<VetRecord> GetAll();
    }
}