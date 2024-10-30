using FluentValidation;
using POO_A3_Pet.Database.Models;
using POO_A4.Services.DTOs;
using System;

namespace POO_A3_Pet.Services.Validators
{
    public class AppointmentValidator : AbstractValidator<AppointmentDTO>
    {
        public AppointmentValidator()
        {
            {
                RuleFor(a => a.observation)
                    .MaximumLength(255).WithMessage("A observação deve ter no máximo 255 caracteres.");

                RuleFor(a => a.appointmentDate)
                    .NotEmpty().WithMessage("A data do agendamento é obrigatória.")
                    .GreaterThan(DateTime.Now).WithMessage("A data do agendamento deve ser no futuro.");

                RuleFor(a => a.clientid)
                    .NotEmpty().WithMessage("O ID do cliente é obrigatório.")
                    .GreaterThan(0).WithMessage("O ID do cliente deve ser um número positivo.");

                RuleFor(a => a.petid)
                    .NotEmpty().WithMessage("O ID do pet é obrigatório.")
                    .GreaterThan(0).WithMessage("O ID do pet deve ser um número positivo.");

                RuleFor(a => a.productid)
                   .NotEmpty().WithMessage("O ID do produto é obrigatório.")
                   .WithMessage("O ID do pet deve ser um número positivo.");

                // TODO: verificar no banco se o ID do produto é do tipo servico.
                //nao pode ser do tipo produto quando acontece um agendamento.
            }
        }
    }
}