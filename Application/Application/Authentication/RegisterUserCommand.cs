﻿using Domain.Authentication;
using MediatR;

namespace Application.Authentication
{
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public RegisterUserCommand(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
