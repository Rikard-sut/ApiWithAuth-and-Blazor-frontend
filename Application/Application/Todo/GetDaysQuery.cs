using Domain.TodoTask;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Todo
{
    public class GetDaysQuery : IRequest<GetDaysResponse>
    {
        public GetDaysQuery(string username)
        {
            GetDaysOnUserName = username;
        }

        public string GetDaysOnUserName { get; set; }
    }
}
