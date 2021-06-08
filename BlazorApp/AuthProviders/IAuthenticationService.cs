using System.Threading.Tasks;
using BlazorApp.AuthModels;

namespace BlazorApp.AuthProviders
{
    public interface IAuthenticationService
    {
        Task<AuthResponseDTO> Login(LoginModel userForAuthentication);
        Task Logout();
        Task<RegistrationResponseDto> RegisterUser(RegisterModel userForRegistration);
    }
}