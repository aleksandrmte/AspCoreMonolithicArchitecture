using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.TodoLists.Dto;
using MediatR;

namespace ApplicationCore.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Color { get; set; }
        public ProjectDto Project { get; set; }
    }
}
