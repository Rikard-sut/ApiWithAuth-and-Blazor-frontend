using Application.Authentication;
using Domain.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IAuthenticationService
    {
        Task<JwtSecurityToken> Login(LoginUserCommand command);
        Task<RegisterUserResponse> RegisterUser(RegisterUserCommand command);
        Task<RegisterUserResponse> RegisterAdmin(RegisterAdminCommand command);
    }
}
