using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.TodoLists.Dto;
using ApplicationCore.TodoLists.Interfaces;
using ApplicationCore.TodoLists.Specifications;
using AutoMapper;
using MediatR;

namespace ApplicationCore.TodoLists.Queries.GetTodoLists
{
    public class GetTodoListsQueryHandler : IRequestHandler<GetTodoListsQuery, TodoListsVm>
    {
        private readonly ITodoListRepository _todoListRepository;
        private readonly IMapper _mapper;

        public GetTodoListsQueryHandler(ITodoListRepository todoListRepository, IMapper mapper)
        {
            _todoListRepository = todoListRepository;
            _mapper = mapper;
        }

        public async Task<TodoListsVm> Handle(GetTodoListsQuery request, CancellationToken cancellationToken)
        {
            var specification = new TodoListWithTodoItemsSpecification();
            var data = await _todoListRepository.ListAsync(specification);
            return new TodoListsVm
            {
                Lists = data.Select(_mapper.Map<TodoListDto>)
                    .OrderBy(t => t.Title).ToList()
            };
        }
    }
}
