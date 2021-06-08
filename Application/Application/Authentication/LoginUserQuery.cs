using Domain.Authentication;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication
{
    public class LoginUserQuery : IRequest<LoginUserResponse>
    {
        public LoginUserQuery(string username, string password, IConfiguration configuration)
        {
            Username = username;
            Password = password;
            Config = configuration;
        }
        public string Username { get; set; }

        public string Password { get; set; }

        public IConfiguration Config { get; set; }
    }
}
