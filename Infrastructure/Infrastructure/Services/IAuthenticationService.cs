using Application.Authentication;
using Domain.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IAuthenticationService
    {
        Task<JwtSecurityToken> Login(LoginUserQuery model);
        Task<RegisterUserResponse> RegisterUser(RegisterUserQuery model);
        Task<RegisterUserResponse> RegisterAdmin(RegisterAdminQuery model);
    }
}
