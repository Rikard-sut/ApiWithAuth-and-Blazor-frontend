using Application.Todo;
using Domain.TodoTask;
using Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithAuth.Handlers.TodoTasks
{
    public class ClearTodoTasksHandler : IRequestHandler<ClearTodoTasksQuery, ClearTodoTasksResponse>
    {
        private readonly ISqlService _todoTaskService;

        public ClearTodoTasksHandler(ISqlService sqlService)
        {
            _todoTaskService = sqlService;
        }

        public async Task<ClearTodoTasksResponse> Handle(ClearTodoTasksQuery request, CancellationToken cancellationToken)
        {
            var response = await _todoTaskService.ClearTodoTasksAsync(request);

            if (!response)
                return new ClearTodoTasksResponse { Error = "Couldnt delete tasks", Success = response };

            return new ClearTodoTasksResponse { Message = "Removed all tasks", Success = response };
        }
    }
}
