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
    public class ClearTodoTasksHandler : IRequestHandler<ClearTodoTasksCommand, ClearTodoTasksResponse>
    {
        private readonly ISqlService _todoTaskService;

        public ClearTodoTasksHandler(ISqlService sqlService)
        {
            _todoTaskService = sqlService;
        }

        public async Task<ClearTodoTasksResponse> Handle(ClearTodoTasksCommand command, CancellationToken cancellationToken)
        {
            var response = await _todoTaskService.ClearTodoTasksAsync(command);

            if (!response)
                return new ClearTodoTasksResponse { Error = "Couldnt delete tasks", Success = response };

            return new ClearTodoTasksResponse { Message = "Removed all tasks", Success = response };
        }
    }
}
