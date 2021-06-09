using Application.Authentication;
using Domain.Authentication;
using Infrastructure.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithAuth.Handlers.Authentication
{
    public class RegisterAdminHandler : IRequestHandler<RegisterAdminQuery, RegisterUserResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterAdminHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<RegisterUserResponse> Handle(RegisterAdminQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RegisterAdmin(request);
        }
    }
}
