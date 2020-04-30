using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Common.Specifications;
using Domain.Entities.TodoAggregate;

namespace ApplicationCore.TodoLists.Specifications
{
    public sealed class TodoListGetByNameSpecification : BaseSpecification<TodoList>
    {
        public TodoListGetByNameSpecification(string title)
            : base(t => t.Title == title)
        {
            
        }
    }
}
