using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.TodoLists.Dto;
using MediatR;

namespace ApplicationCore.TodoLists.Queries.GetTodoList
{
    public class GetTodoListQuery: IRequest<TodoListDto>
    {
        public int Id { get; set; }

        public GetTodoListQuery(int id)
        {
            Id = id;
        }
    }
}
