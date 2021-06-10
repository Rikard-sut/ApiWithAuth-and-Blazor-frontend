using Application.Authentication;
using Application.Todo;
using Microsoft.Extensions.Configuration;

namespace ApiWithAuth.Factories
{
    internal static class MediatorRequestFactory
    {
        internal static LoginUserCommand GetLoginUserCommand(LoginRequest request, IConfiguration configuration)
        {
            return new LoginUserCommand(request.Username, request.Password, configuration);
        }

        internal static RegisterUserCommand GetRegisterUseCommand(RegisterUserRequest request)
        {
            return new RegisterUserCommand(request.Username, request.Email, request.Password);
        }

        internal static RegisterUserCommand GetRegisterAdminCommand(RegisterUserRequest request)
        {
            return new RegisterUserCommand(request.Username, request.Email, request.Password);
        }

        internal static GetDaysQuery GetGetDaysQuery(string username)
        {
            return new GetDaysQuery(username);
        }

        internal static GetDayQuery GetGetDayQuery(int dayId, string username)
        {
            return new GetDayQuery(dayId, username);
        }

        internal static AddTodoTaskCommand GetAddTodoTaskCommand(AddTodoTaskRequest request, string username)
        {
            return new AddTodoTaskCommand(request.Description, request.IsCompleted, request.DayId, username);
        }

        internal static UpdateTodoTaskCommand GetUpdateTodoTaskCommand(UpdateTodoTaskRequest request)
        {
            return new UpdateTodoTaskCommand(request.TodoTaskId, request.Description, request.IsCompleted);
        }

        internal static ClearTodoTasksCommand GetClearTodoTasksCommand(string username)
        {
            return new ClearTodoTasksCommand(username);
        }

        internal static CompleteTodoTaskCommand GetCompleteTodoTaskCommand(int todoTaskId)
        {
            return new CompleteTodoTaskCommand(todoTaskId);
        }
    }
}
