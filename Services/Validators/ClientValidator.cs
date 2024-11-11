using FluentValidation;
using POO_A4.Services.DTOs;
using System;

namespace POO_A4.Services.Validators
{
    public class ClientValidator : AbstractValidator<ClientDTO>
    {
        public ClientValidator()
        {
            RuleFor(c => c.name)
                .NotEmpty().WithMessage("O nome do cliente é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do cliente deve ter no máximo 100 caracteres.");

            RuleFor(c => c.email)
                .NotEmpty().WithMessage("O e-mail do cliente é obrigatório.")
                .EmailAddress().WithMessage("O e-mail fornecido é inválido.");

            RuleFor(c => c.adress)
                .NotEmpty().WithMessage("O endereço do cliente é obrigatório.")
                .MaximumLength(255).WithMessage("O endereço do cliente deve ter no máximo 255 caracteres.");

            RuleFor(c => c.phone)
                .NotEmpty().WithMessage("O telefone do cliente é obrigatório.")
                .Matches(@"^\(\d{2}\)\s\d{4,5}-\d{4}$").WithMessage("O formato do telefone é inválido.");
        }
    }
}