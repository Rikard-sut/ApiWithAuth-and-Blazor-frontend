using Application.Authentication;
using Domain.Authentication;
using Infrastructure.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithAuth.Handlers.Authentication
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterUserHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            return await _authenticationService.RegisterUser(command);
        }
    }
}
