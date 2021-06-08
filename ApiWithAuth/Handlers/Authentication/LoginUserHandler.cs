using Application.Authentication;
using Domain.Authentication;
using Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithAuth.Handlers.Authentication
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, LoginUserResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginUserHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<LoginUserResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var token = await _authenticationService.Login(request);

            return new LoginUserResponse { Token = token };         
        }
    }
}
