using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.TodoLists.Dto;
using MediatR;

namespace ApplicationCore.TodoLists.Queries.GetTodoLists
{
    public class GetTodoListsQuery: IRequest<TodoListsVm>
    {
    }
}
