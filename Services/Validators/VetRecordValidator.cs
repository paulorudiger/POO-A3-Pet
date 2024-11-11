using FluentValidation;
using POO_A4.Services.DTOs;
using System;

namespace POO_A4.Services.Validators
{
    public class VetRecordValidator : AbstractValidator<VetRecordDTO>
    {
        public VetRecordValidator()
        {
            RuleFor(vr => vr.vetName)
                .NotEmpty().WithMessage("O nome do veterinário é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do veterinário deve ter no máximo 100 caracteres.");

            RuleFor(vr => vr.petid)
                .NotEmpty().WithMessage("O ID do pet é obrigatório.");

            RuleFor(vr => vr.observations)
                .NotEmpty().WithMessage("As observações são obrigatórias.")
                .MaximumLength(500).WithMessage("As observações devem ter no máximo 500 caracteres.");

            RuleFor(vr => vr.appointmentDate)
                .NotEmpty().WithMessage("A data do agendamento é obrigatória.")
                .GreaterThan(DateTime.Now).WithMessage("A data do agendamento deve ser no futuro.");
        }
    }
}