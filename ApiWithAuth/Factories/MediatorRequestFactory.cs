using Application.Authentication;
using Application.Todo;
using Microsoft.Extensions.Configuration;

namespace ApiWithAuth.Factories
{
    internal static class MediatorRequestFactory
    {
        internal static LoginUserQuery GetLoginUserQuery(LoginRequest request, IConfiguration configuration)
        {
            return new LoginUserQuery(request.Username, request.Password, configuration);
        }

        internal static RegisterUserQuery GetRegisterUserQuery(RegisterUserRequest request)
        {
            return new RegisterUserQuery(request.Username, request.Email, request.Password);
        }

        internal static RegisterUserQuery GetRegisterAdminQuery(RegisterUserRequest request)
        {
            return new RegisterUserQuery(request.Username, request.Email, request.Password);
        }

        internal static GetDaysQuery GetGetDaysQuery(string username)
        {
            return new GetDaysQuery(username);
        }

        internal static GetDayQuery GetGetDayQuery(int dayId, string username)
        {
            return new GetDayQuery(dayId, username);
        }

        internal static AddTodoTaskQuery GetAddTodoTaskQuery(AddTodoTaskRequest request, string username)
        {
            return new AddTodoTaskQuery(request.Description, request.IsCompleted, request.DayId, username);
        }

        internal static UpdateTodoTaskQuery GetUpdateTodoTaskQuery(UpdateTodoTaskRequest request)
        {
            return new UpdateTodoTaskQuery(request.TodoTaskId, request.Description, request.IsCompleted);
        }

        internal static ClearTodoTasksQuery GetClearTodoTasksQuery(string username)
        {
            return new ClearTodoTasksQuery(username);
        }

        internal static CompleteTodoTaskQuery GetCompleteTodoTaskQuery(int todoTaskId)
        {
            return new CompleteTodoTaskQuery(todoTaskId);
        }
    }
}
