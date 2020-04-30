using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.TodoLists.Interfaces;
using Domain.Entities.TodoAggregate;

namespace Infrastructure.Data.Repositories
{
    public class TodoListRepository : EfRepository<TodoList>, ITodoListRepository
    {
        public TodoListRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
