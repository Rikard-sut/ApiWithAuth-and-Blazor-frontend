using Application.Authentication;
using Domain.Authentication;
using Infrastructure.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithAuth.Handlers.Authentication
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginUserHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<LoginUserResponse> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var token = await _authenticationService.Login(command);

            return new LoginUserResponse { Token = token };
        }
    }
}
