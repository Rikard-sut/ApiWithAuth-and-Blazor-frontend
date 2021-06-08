using Domain.TodoTask;
using MediatR;

namespace Application.Todo
{
    public class UpdateTodoTaskQuery : IRequest<UpdateTodoTaskResponse>
    {
        public UpdateTodoTaskQuery(int id, string description, bool isCompleted)
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
