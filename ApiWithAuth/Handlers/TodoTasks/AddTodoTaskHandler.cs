using Application.Todo;
using Domain.TodoTask;
using Infrastructure.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithAuth.Handlers.TodoTasks
{
    public class AddTodoTaskHandler : IRequestHandler<AddTodoTaskCommand, AddTodoTaskResponse>
    {
        private readonly ISqlService _todoTaskService;

        public AddTodoTaskHandler(ISqlService sqlService)
        {
            _todoTaskService = sqlService;
        }

        public async Task<AddTodoTaskResponse> Handle(AddTodoTaskCommand command, CancellationToken cancellationToken)
        {
            var response = await _todoTaskService.AddTodoTaskAsync(command);

            if (!response)
                return new AddTodoTaskResponse { Error = "Couldnt add task", Success = response };

            return new AddTodoTaskResponse { Success = response };
        }
    }
}
