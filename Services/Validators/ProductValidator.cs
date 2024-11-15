using FluentValidation;
using POO_A4.Services.DTOs;

namespace POO_A4.Services.Validators
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(p => p.productName)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do produto deve ter no máximo 100 caracteres.");

            RuleFor(p => p.description)
                .NotEmpty().WithMessage("A descrição do produto é obrigatória.")
                .MaximumLength(255).WithMessage("A descrição do produto deve ter no máximo 255 caracteres.");

            RuleFor(p => p.price)
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");

            RuleFor(p => p.productType)
                .NotEmpty().WithMessage("O tipo do produto é obrigatório.");
        }
    }
}