using Domain.TodoTask;
using MediatR;

namespace Application.Todo
{
    public class CompleteTodoTaskCommand : IRequest<CompleteTodoTaskResponse>
    {
        public CompleteTodoTaskCommand(int todoTaskId)
        {
            TodoTaskId = todoTaskId;
        }
        public int TodoTaskId { get; set; }
    }
}
