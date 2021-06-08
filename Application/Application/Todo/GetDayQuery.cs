using Domain.TodoTask;
using MediatR;

namespace Application.Todo
{
    public class GetDayQuery : IRequest<GetDayResponse>
    {
        public GetDayQuery(int dayId, string username)
        {
            DayId = dayId;
            GetDayOnUsername = username;
        }

        public string GetDayOnUsername { get; set; }
        public int DayId { get; set; }
    }
}
