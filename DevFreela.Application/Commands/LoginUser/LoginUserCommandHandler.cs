using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //UTILIZAR O MESMO ALGORITMO PARA CRIRAR O HASH DESSA SENHA
            var passowordHash = _authService.ComputeSha256Hash(request.Password);

            //BUSCAR NO MEU DB UM USER QUE TENHA O MEU EMAIL E A SENHA EM FORMATO HASH
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passowordHash);

            //SE NÃO EXISTIR, ERRO NO LOGIN
            if (user == null)
                return null;

            //SE EXISTIR, GERO TOKEN USANDO DADOS DO USER
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Email, token);
        }
    }
}
