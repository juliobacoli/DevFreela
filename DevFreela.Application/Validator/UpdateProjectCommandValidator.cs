using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Application.Commands.UpdateProject;

namespace DevFreela.Application.Validator
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(30)
                .WithMessage("Tamanho máximo do titulo é de 30 caracteres");

            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo 255 caracteres");
        }
    }
}
