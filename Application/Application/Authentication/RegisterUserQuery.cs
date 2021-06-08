﻿using Domain.Authentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication
{
    public class RegisterUserQuery : IRequest<RegisterUserResponse>
    {
        public RegisterUserQuery(string username, string email, string password)
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