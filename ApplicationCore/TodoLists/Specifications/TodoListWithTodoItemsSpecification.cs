using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Common.Specifications;
using Domain.Entities.TodoAggregate;

namespace ApplicationCore.TodoLists.Specifications
{
    public sealed class TodoListWithTodoItemsSpecification : BaseSpecification<TodoList>
    {
        public TodoListWithTodoItemsSpecification()
            : base(t => true)
        {
            AddIncludes(query => query.Include(o => o.TodoItems));
        }
    }
}
