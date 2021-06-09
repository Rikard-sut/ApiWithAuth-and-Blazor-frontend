using Domain.TodoTask;
using MediatR;

namespace Application.Todo
{
    public class CompleteTodoTaskQuery : IRequest<CompleteTodoTaskResponse>
    {
        public CompleteTodoTaskQuery(int todoTaskId)
        {
            TodoTaskId = todoTaskId;
        }
        public int TodoTaskId { get; set; }
    }
}
