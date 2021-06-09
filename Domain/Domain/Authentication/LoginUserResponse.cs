using System.IdentityModel.Tokens.Jwt;

namespace Domain.Authentication
{
    public class LoginUserResponse
    {
        public JwtSecurityToken Token { get; set; }
        
        public string Error { get; set; }
    }
}
