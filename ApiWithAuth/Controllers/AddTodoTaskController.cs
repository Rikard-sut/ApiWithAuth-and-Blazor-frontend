using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiWithAuth.Factories;
using Application.Todo;
using Domain.Authentication;
using Infrastructure.Database.Entities;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiWithAuth.Controllers
{
    [Authorize]
    [Route("api/todoTask")]
    [ApiController]
    public class AddTodoTaskController : ControllerBase
    {
        private readonly ILogger<AddTodoTaskController> _logger;
        private readonly IMediator _mediator;

        public AddTodoTaskController(ILogger<AddTodoTaskController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddToDoTaskAsync([FromBody] AddTodoTaskRequest request)
        {
            var addTodoTaskQuery = MediatorRequestFactory.GetAddTodoTaskQuery(request, ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value);

            var response = await _mediator.Send(addTodoTaskQuery);
            
            if(!response.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }
    }
}
