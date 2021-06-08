using Application.Authentication;
using Domain.Authentication;
using Infrastructure.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithAuth.Handlers.Authentication
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserQuery, RegisterUserResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterUserHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RegisterUser(request);
        }
    }
}
