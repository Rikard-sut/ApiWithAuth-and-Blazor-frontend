﻿using Domain.TodoTask;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Todo
{
    public class ClearTodoTasksQuery : IRequest<ClearTodoTasksResponse>
    {
        public ClearTodoTasksQuery(string username)
        {
            ClearTasksForUsername = username;
        }

        public string ClearTasksForUsername { get; set; }
    }
}