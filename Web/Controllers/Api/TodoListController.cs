using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.TodoLists.Commands.CreateTodoList;
using ApplicationCore.TodoLists.Dto;
using ApplicationCore.TodoLists.Queries.GetTodoList;
using ApplicationCore.TodoLists.Queries.GetTodoLists;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TodoListController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<TodoListsVm>> Get()
        {
            return await Mediator.Send(new GetTodoListsQuery());
        }

        [HttpGet("{id}")]
        public async Task<TodoListDto> Get(int id)
        {
            return await Mediator.Send(new GetTodoListQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoListCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}