using Application.Authentication;
using Domain.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IAuthenticationService
    {
        Task<JwtSecurityToken> Login(LoginRequest model, SymmetricSecurityKey authSigningKey, IConfiguration _configuration);
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest model);
        Task<RegisterUserResponse> RegisterAdmin(RegisterUserRequest model);
    }
}
