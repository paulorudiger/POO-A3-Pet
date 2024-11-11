using FluentValidation;
using POO_A4.Services.DTOs;

namespace POO_A4.Services.Validators
{
    public class PetValidator : AbstractValidator<PetDTO>
    {
        public PetValidator()
        {
            RuleFor(p => p.name)
                .NotEmpty().WithMessage("O nome do pet é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do pet deve ter no máximo 100 caracteres.");

            RuleFor(p => p.description)
                .NotEmpty().WithMessage("A descrição do pet é obrigatória.")
                .MaximumLength(255).WithMessage("A descrição do pet deve ter no máximo 255 caracteres.");

            RuleFor(p => p.breed)
                .NotEmpty().WithMessage("A raça do pet é obrigatória.")
                .MaximumLength(50).WithMessage("A raça do pet deve ter no máximo 50 caracteres.");

            RuleFor(p => p.weight)
                .NotEmpty().WithMessage("O peso do pet é obrigatório.");
        }
    }
}