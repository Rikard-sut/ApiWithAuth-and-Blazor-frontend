using System.Security.Claims;
using System.Threading.Tasks;
using ApiWithAuth.Factories;
using Application.Todo;
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
    public class TodoTaskController : ControllerBase
    {
        private readonly ILogger<TodoTaskController> _logger;
        private readonly IMediator _mediator;

        public TodoTaskController(ILogger<TodoTaskController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddToDoTaskAsync([FromBody] AddTodoTaskRequest request)
        {
            var addTodoTaskCommand = MediatorRequestFactory.GetAddTodoTaskCommand(request, ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value);

            var response = await _mediator.Send(addTodoTaskCommand);
            
            if(!response.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateTodoTaskAsync([FromBody] UpdateTodoTaskRequest request)
        {
            var updateTodoTaskCommand = MediatorRequestFactory.GetUpdateTodoTaskCommand(request);

            var response = await _mediator.Send(updateTodoTaskCommand);

            if (!response.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, response);

            return Ok(response);
        }

        [HttpGet]
        [Route("complete/{todoTaskId}")]
        public async Task<IActionResult> CompleteTodoTaskAsync(int todoTaskId)
        {
            var completeTodoTaskCommand = MediatorRequestFactory.GetCompleteTodoTaskCommand(todoTaskId);

            var response = await _mediator.Send(completeTodoTaskCommand);

            if (!response.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, response);

            return Ok(response);
        }

        [HttpGet]
        [Route("clear")]
        public async Task<IActionResult> ClearAllTodoTasksForUser()
        {
            var clearTodoTasksCommand = MediatorRequestFactory.GetClearTodoTasksCommand(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value);

            var response = await _mediator.Send(clearTodoTasksCommand);

            if (!response.Success)
                return StatusCode(StatusCodes.Status500InternalServerError, response);

            return Ok(response);
        }
    }
}
