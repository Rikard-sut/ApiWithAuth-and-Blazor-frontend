using Application.Todo;
using Domain.TodoTask;
using Infrastructure.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiWithAuth.Handlers.TodoTasks
{
    public class GetDaysHandler : IRequestHandler<GetDaysQuery, GetDaysResponse>
    {
        private readonly ISqlService _todoTaskService;

        public GetDaysHandler(ISqlService sqlService)
        {
            _todoTaskService = sqlService;
        }
        public async Task<GetDaysResponse> Handle(GetDaysQuery request, CancellationToken cancellationToken)
        {
            var response = await _todoTaskService.GetDaysAsync(request);

            if (response == null)
                return new GetDaysResponse { Error = "Error getting days" };

            return new GetDaysResponse { Days = response };
        }
    }
}
