using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiWithAuth.Authentication;
using ApiWithAuth.TodoDbEntities;
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
        private readonly ISqlService _SqlService;
        public AddTodoTaskController(ILogger<AddTodoTaskController> logger, ISqlService sqlService)
        {
            _logger = logger;
            _SqlService = sqlService;
        }
        [HttpPost]
        public async Task<IActionResult> AddToDotaskAsync([FromBody] TodoTask todoTask)
        {
            var userName = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value;
            todoTask.UserName = userName;

            var response = await _SqlService.AddTodoTaskAsync(todoTask);
            
            if(response == true)
            {
                return Ok(new Response { Status = "Success", Message = "Sucessfully added task" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Task creation failed, please try again." });
            }
        }
    }
}
