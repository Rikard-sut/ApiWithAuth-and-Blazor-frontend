using Domain.TodoTask;
using MediatR;

namespace Application.Todo
{
    public class AddTodoTaskQuery : IRequest<AddTodoTaskResponse>
    {
        public AddTodoTaskQuery(string description, bool isCompleted, int dayId, string username)
        {
            Description = description;
            IsCompleted = isCompleted;
            DayId = dayId;
            AddTodoTaskOnUsername = username;
        }

        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int DayId { get; set; }
        public string AddTodoTaskOnUsername { get; set; }
    }
}
