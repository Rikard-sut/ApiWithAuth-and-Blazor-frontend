using Domain.TodoTask;
using MediatR;

namespace Application.Todo
{
    public class UpdateTodoTaskCommand : IRequest<UpdateTodoTaskResponse>
    {
        public UpdateTodoTaskCommand(int id, string description, bool isCompleted)
        {
            TodoTaskId = id;
            Description = description;
            IsCompleted = isCompleted;
        }

        public int TodoTaskId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
