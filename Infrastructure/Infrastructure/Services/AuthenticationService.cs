using Application.Authentication;
using Domain.Authentication;
using Infrastructure.Authentication.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<JwtSecurityToken> Login(LoginRequest model, SymmetricSecurityKey authSigningKey, IConfiguration _configuration)
        {
            //finds the user so we know they exists. and checks the password.
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                //creates the token to give to the user.
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return token;
            }
            return null;
        }

        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest model)
        {
            //Finds the user if it exists in the database and returns proper errormessage.
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return new RegisterUserResponse { Status = "Error", Message = "User already exists!" };

            //Creates a new applicationuser from the info of RegisterModel coming in frombody.
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            //tries to create the user and save it in the db.
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new RegisterUserResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." };

            return new RegisterUserResponse { Status = "Success", Message = "User created successfully!" };
        }

        public async Task<RegisterUserResponse> RegisterAdmin(RegisterUserRequest model)
        {
            //Finds the user if it exists in the database and returns proper errormessage.
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return new RegisterUserResponse { Status = "Error", Message = "User already exists!" };

            //Creates a new applicationuser from the info of RegisterModel coming in frombody.
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new RegisterUserResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." };

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return new RegisterUserResponse { Status = "Success", Message = "User created successfully!" };
        }

    }
}
