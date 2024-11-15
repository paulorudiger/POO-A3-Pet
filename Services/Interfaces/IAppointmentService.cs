using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using System.Collections.Generic;

namespace POO_A3_Pet.Services.Interfaces
{
    // A interface IAppointmentService define os métodos para manipulação de agendamentos.
    // Esses métodos seguem o padrão CRUD (Create, Read, Update, Delete) e usam DTOs como parâmetro para garantir que apenas dados necessários sejam transmitidos.
    // Nesta interface, são passados os DTOs nos parametros
    public interface IAppointmentService
    {
        // Método para adicionar um agendamento.
        // O parâmetro dto (AppointmentDTO) é usado para garantir que os dados inseridos estejam na estrutura correta.
        // Isso promove a **abstração** e **encapsulamento** dos dados, separando as entidades de domínio das camadas de apresentação.
        public Appointment Add(AppointmentDTO dto);

        // Método para atualizar um agendamento existente.
        // O parâmetro dto (AppointmentDTO) permite que apenas os dados necessários para a atualização sejam passados, sem a necessidade de acessar diretamente a entidade.
        public Appointment Update(AppointmentDTO dto);

        // Método para excluir um agendamento.
        // O parâmetro id identifica de forma única o agendamento que será removido.
        public void Delete(int id);

        // Método para buscar um agendamento pelo seu ID.
        // O método retorna a entidade `Appointment` correspondente ao ID fornecido.
        public Appointment GetById(int id);

        // Método para buscar todos os agendamentos.
        // O método retorna uma lista de todas as entidades `Appointment` armazenadas no banco de dados.
        public IEnumerable<Appointment> GetAll();
    }
}