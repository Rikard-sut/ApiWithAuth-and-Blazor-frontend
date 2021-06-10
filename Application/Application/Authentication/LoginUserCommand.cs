using Domain.Authentication;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Authentication
{
    public class LoginUserCommand : IRequest<LoginUserResponse>
    {
        public LoginUserCommand(string username, string password, IConfiguration configuration)
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
