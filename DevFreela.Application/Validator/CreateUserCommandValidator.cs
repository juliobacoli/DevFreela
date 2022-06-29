using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFreela.Application.Validator
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido");

            RuleFor(x => x.Password)
                .Must(ValidPassoword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, caracteres especiais, pelo menos 1 upper e 1 lower e 1 numero");

            RuleFor(p => p.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório");
        }
        public bool ValidPassoword(string password)
        {
            //Quer dizer que senha aceita pelo menos 8 caracteres, aceita caracteres especiais, pelo menos 1 upper e 1 lower e 1 numero
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
