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
    public class CompleteTodoTaskHandler : IRequestHandler<CompleteTodoTaskQuery, CompleteTodoTaskResponse>
    {
        private readonly ISqlService _todoTaskService;

        public CompleteTodoTaskHandler(ISqlService sqlService)
        {
            _todoTaskService = sqlService;
        }

        public async Task<CompleteTodoTaskResponse> Handle(CompleteTodoTaskQuery request, CancellationToken cancellationToken)
        {
            var response = await _todoTaskService.CompleteTodoTaskAsync(request);

            if (!response)
                return new CompleteTodoTaskResponse { Error = "Couldnt complete task", Success = response };

            return new CompleteTodoTaskResponse { Success = response };
        }
    }
}
