using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.TodoLists.Interfaces;
using Domain.Entities.TodoAggregate;
using MediatR;

namespace ApplicationCore.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
    {
        private readonly ITodoListRepository _todoListRepository;

        public CreateTodoListCommandHandler(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoList(request.Title, request.Color,
                new Project(request.Project.Name, request.Project.Description),
                new List<TodoItem>());
            await _todoListRepository.AddAsync(entity);
            return entity.Id;
        }
    }
}
