using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using ApiWithAuth.Factories;
using Application.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiWithAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public AuthenticateController(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var loginQuery = MediatorRequestFactory.GetLoginUserQuery(request, _configuration);
            var response = await _mediator.Send(loginQuery);

            if (response.Token == null)
            {
                return Unauthorized();
            }

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(response.Token),
                expiration = response.Token.ValidTo
            });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var registerUserQuery = MediatorRequestFactory.GetRegisterUserQuery(request);
            var response = await _mediator.Send(registerUserQuery);

            if(response.Status == "Error")
                return StatusCode(StatusCodes.Status500InternalServerError, response);

            return Ok(response);
        }

        
        [HttpPost]
        [Route("register-admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserRequest request)
        {
            var registerAdminQuery = MediatorRequestFactory.GetRegisterAdminQuery(request);
            var response = await _mediator.Send(registerAdminQuery);

            if (response.Status == "Error")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }
    }
}
