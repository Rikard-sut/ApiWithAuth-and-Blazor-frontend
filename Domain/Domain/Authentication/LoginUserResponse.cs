using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Domain.Authentication
{
    public class LoginUserResponse
    {
        public JwtSecurityToken Token { get; set; }
        
        public string Error { get; set; }
    }
}
