using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.EntityFrameworkCore;
using POO_A3_Pet.Database.Models;
using POO_A3_Pet.Database.Repositories;
using POO_A3_Pet.Domain.Enums;
using POO_A3_Pet.Services.Interfaces;
using POO_A3_Pet.Services.Mappers;
using POO_A3_Pet.Services.Parsers;
using POO_A3_Pet.Services.Validators;
using POO_A4.Database;
using POO_A4.Interfaces;
using POO_A4.Services;
using POO_A4.Services.DTOs;
using POO_A4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POO_A3_Pet.Services
{
    // A classe AppointmentService implementa a interface IAppointmentService e é responsável por fornecer os métodos
    // necessários para manipular os agendamentos (Appointments) no sistema.
    // Ela segue o padrão de negócio e encapsula a lógica relacionada a operações CRUD, validações e regras de negócios.
    public class AppointmentService : IAppointmentService
    {
        // A variável _repository é uma instância do repositório para a entidade Appointment.
        // O repositório abstrai o acesso ao banco de dados, fornecendo métodos para realizar operações CRUD.
        private readonly IRepository<Appointment> _repository;

        // A variável _parser é uma instância da classe AppointmentParser, que é responsável por converter os DTOs em entidades.
        private readonly AppointmentParser _parser;

        // A variável _dbcontext é uma instância do contexto do banco de dados, usada para interagir diretamente com o banco de dados.
        private readonly PetDbContext _dbcontext;

        // O construtor da classe recebe o PetDbContext e inicializa o repositório, o parser e o contexto do banco de dados.
        public AppointmentService(PetDbContext dbcontext)
        {
            _repository = new Repository<Appointment>(dbcontext);  // Cria uma instância do repositório para Appointment.
            _parser = new AppointmentParser();  // Cria uma instância do parser que será usado para conversão de DTOs.
            _dbcontext = dbcontext;  // Atribui o contexto do banco de dados.
        }

        // Método responsável por adicionar um novo agendamento.
        // Primeiro, valida o DTO com o FluentValidation, verifica se o produto é um serviço e cria a entidade de agendamento.
        public Appointment Add(AppointmentDTO dto)
        {
            // Validação do DTO utilizando FluentValidation.
            var validator = new AppointmentValidator();
            validator.ValidateAndThrow(dto);  // Lança uma exceção se a validação falhar.

            // Geração do próximo ID para o agendamento.
            dto.appointmentid = GetNextAppointmentidValue();

            // Cria uma instância de ProductService para acessar as informações do produto.
            ProductService productService = new ProductService(_dbcontext);
            var product = productService.GetById(dto.productid);  // Obtém o produto correspondente ao ID do DTO.

            // Verificação se o produto é do tipo 'Service'. Caso contrário, lança uma exceção.
            if (product.productType != ProductType.Service)
            {
                throw new InvalidOperationException("The product is not of type 'Service'. Only products of type 'Service' can be scheduled.");
            }

            // Converte o DTO para a entidade Appointment utilizando o parser.
            var entity = _parser.ParseAppointment(dto);
            _repository.Add(entity);  // Adiciona a entidade ao repositório (banco de dados).

            return entity;  // Retorna a entidade recém-criada.
        }

        // Método para obter um agendamento pelo seu ID.
        // Se o agendamento não for encontrado, lança uma exceção.
        public Appointment GetById(int id)
        {
            var entity = _repository.GetById(id);  // Busca o agendamento pelo ID.
            if (entity == null)
            {
                throw new KeyNotFoundException("Appointment not found");  // Lança exceção se o agendamento não for encontrado.
            }

            return entity;  // Retorna o agendamento encontrado.
        }

        // Método para obter todos os agendamentos do banco de dados.
        public IEnumerable<Appointment> GetAll()
        {
            return _repository.GetAll();  // Retorna todos os agendamentos.
        }

        // Método para excluir um agendamento.
        // Se o agendamento não for encontrado, lança uma exceção.
        public void Delete(int appointmentid)
        {
            var entity = _repository.GetById(appointmentid);  // Busca o agendamento pelo ID.
            if (entity == null)
            {
                throw new KeyNotFoundException("Appointment not found");  // Lança exceção se o agendamento não for encontrado.
            }

            _repository.Delete(entity);  // Deleta o agendamento do repositório (banco de dados).
        }

        // Método para atualizar um agendamento existente.
        // O agendamento é validado e, em seguida, atualizado no repositório.
        public Appointment Update(AppointmentDTO dto)
        {
            // Validação do DTO utilizando FluentValidation.
            var validator = new AppointmentValidator();
            validator.ValidateAndThrow(dto);  // Lança uma exceção se a validação falhar.

            var id = dto.appointmentid;
            var existingEntity = _repository.GetById(id);  // Busca o agendamento pelo ID.
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Appointment not found");  // Lança exceção se o agendamento não for encontrado.
            }

            // Converte o DTO para a entidade Appointment utilizando o parser.
            var updatedEntity = _parser.ParseAppointment(dto);
            updatedEntity.appointmentid = id;  // Garante que o ID do agendamento não seja alterado.

            _repository.Update(updatedEntity);  // Atualiza o agendamento no repositório (banco de dados).
            return updatedEntity;  // Retorna o agendamento atualizado.
        }

        // Método que calcula o próximo valor do ID para o agendamento.
        // Ele verifica o maior ID existente no banco de dados e retorna o próximo valor sequencial.
        public int GetNextAppointmentidValue()
        {
            var getAll = _repository.GetAll();

            // Lógica para controlar a PrimaryKey.
            if (!getAll.Any())
            {
                return 1;  // Retorna 1 se não houver agendamentos no banco de dados.
            }
            return getAll.Max(a => a.appointmentid) + 1;  // Retorna o próximo ID sequencial.
        }
    }
}