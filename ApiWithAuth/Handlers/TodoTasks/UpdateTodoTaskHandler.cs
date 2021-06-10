using Application.Todo;
using Domain.TodoTask;
using Infrastructure.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithAuth.Handlers.TodoTasks
{
    public class UpdateTodoTaskHandler : IRequestHandler<UpdateTodoTaskCommand, UpdateTodoTaskResponse>
    {
        private readonly ISqlService _todoTaskService;

        public UpdateTodoTaskHandler(ISqlService sqlService)
        {
            _todoTaskService = sqlService;
        }

        public async Task<UpdateTodoTaskResponse> Handle(UpdateTodoTaskCommand request, CancellationToken cancellationToken)
        {
            var response = await _todoTaskService.UpdateTodoTaskAsync(request);

            if (!response)
                return new UpdateTodoTaskResponse { Error = "Couldnt update todo task" , Success = response};

            return new UpdateTodoTaskResponse { Success = response };
        }
    }
}
