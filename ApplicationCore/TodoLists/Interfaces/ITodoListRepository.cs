using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Common.Interfaces;
using Domain.Entities.TodoAggregate;

namespace ApplicationCore.TodoLists.Interfaces
{
    public interface ITodoListRepository : IAsyncRepository<TodoList>
    {
    }
}
