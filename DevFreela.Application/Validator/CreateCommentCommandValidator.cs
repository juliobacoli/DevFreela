using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateComment;

namespace DevFreela.Application.Validator
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(comment => comment.Content)
                .MinimumLength(1)
                .MaximumLength(255)
                .WithMessage("Seu comentário tem mais caracteres de 255 caracteres");
        }
    }
}
