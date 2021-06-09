using Domain.TodoTask;
using MediatR;

namespace Application.Todo
{
    public class ClearTodoTasksQuery : IRequest<ClearTodoTasksResponse>
    {
        public ClearTodoTasksQuery(string username)
        {
            ClearTasksForUsername = username;
        }

        public string ClearTasksForUsername { get; set; }
    }
}
