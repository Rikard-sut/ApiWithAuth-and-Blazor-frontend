using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiWithAuth.TodoDbEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using ApiWithAuth.Authentication;

namespace ApiWithAuth.Controllers
{
    [Authorize]
    [Route("api/getDays")]
    [ApiController]
    public class GetDaysController : ControllerBase
    {

        private readonly ILogger<GetDaysController> _logger;
        private readonly ISqlService _SqlService;
        public GetDaysController(ILogger<GetDaysController> logger, ISqlService sqlService)
        {
            _logger = logger;
            _SqlService = sqlService;
        }
        [HttpGet]
        public async Task<IEnumerable<Day>> Get()
        {
            var userName = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value;
            
            var response = await _SqlService.GetDaysAsync(userName);
            return response.ToArray();
        }
        [HttpGet]
        [Route("/dayOfWeek/{id}")]
        public async Task<Day> GetDay(int id)
        {
            var userName = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name).Value;

            var response = await _SqlService.GetDayAsync(userName, id);
            return response;
        }
    }
}
