using Domain.TodoTask;
using MediatR;

namespace Application.Todo
{
    public class ClearTodoTasksCommand : IRequest<ClearTodoTasksResponse>
    {
        public ClearTodoTasksCommand(string username)
        {
            ClearTasksForUsername = username;
        }

        public string ClearTasksForUsername { get; set; }
    }
}
