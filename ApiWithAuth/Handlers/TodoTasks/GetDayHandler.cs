using Application.Todo;
using Domain.TodoTask;
using Infrastructure.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithAuth.Handlers.TodoTasks
{
    public class GetDayHandler : IRequestHandler<GetDayQuery, GetDayResponse>
    {
        private readonly ISqlService _todoTaskService;

        public GetDayHandler(ISqlService sqlService)
        {
            _todoTaskService = sqlService;
        }
        public async Task<GetDayResponse> Handle(GetDayQuery request, CancellationToken cancellationToken)
        {
            var repsonse = await _todoTaskService.GetDayAsync(request);

            if (repsonse == null)
                return new GetDayResponse { Error = "Couldnt find correct day" };

            return new GetDayResponse { Day = repsonse };
        }
    }
}
