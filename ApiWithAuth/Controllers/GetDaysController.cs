using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Services;
using Infrastructure.Database.Entities;
using MediatR;
using ApiWithAuth.Factories;

namespace ApiWithAuth.Controllers
{
    [Authorize]
    [Route("api/getDays")]
    [ApiController]
    public class GetDaysController : ControllerBase
    {
        private readonly ILogger<GetDaysController> _logger;
        private readonly IMediator _mediator;

        public GetDaysController(ILogger<GetDaysController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDays()
        {
            var getDaysQuery = MediatorRequestFactory.GetGetDaysQuery(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value);

            var response = await _mediator.Send(getDaysQuery);

            if (response.Error != null)
                return StatusCode(StatusCodes.Status500InternalServerError, response);

            return Ok(response);

        }

        [HttpGet]
        [Route("/dayOfWeek/{id}")]
        public async Task<IActionResult> GetDay(int id)
        {
            var getDayQuery = MediatorRequestFactory.GetGetDayQuery(id, ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value);

            var response = await _mediator.Send(getDayQuery);

            if (response.Error != null)
                return StatusCode(StatusCodes.Status500InternalServerError, response);

            return Ok(response);
        }
    }
}
