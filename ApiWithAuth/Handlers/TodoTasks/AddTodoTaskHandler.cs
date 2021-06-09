using Application.Todo;
using Domain.TodoTask;
using Infrastructure.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithAuth.Handlers.TodoTasks
{
    public class AddTodoTaskHandler : IRequestHandler<AddTodoTaskQuery, AddTodoTaskResponse>
    {
        private readonly ISqlService _todoTaskService;

        public AddTodoTaskHandler(ISqlService sqlService)
        {
            _todoTaskService = sqlService;
        }

        public async Task<AddTodoTaskResponse> Handle(AddTodoTaskQuery request, CancellationToken cancellationToken)
        {
            var response = await _todoTaskService.AddTodoTaskAsync(request);

            if (!response)
                return new AddTodoTaskResponse { Error = "Couldnt add task", Success = response };

            return new AddTodoTaskResponse { Success = response };
        }
    }
}
