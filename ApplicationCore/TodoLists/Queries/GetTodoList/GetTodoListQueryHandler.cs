using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.TodoLists.Dto;
using ApplicationCore.TodoLists.Interfaces;
using AutoMapper;
using MediatR;

namespace ApplicationCore.TodoLists.Queries.GetTodoList
{
    public class GetTodoListQueryHandler : IRequestHandler<GetTodoListQuery, TodoListDto>
    {
        private readonly ITodoListRepository _todoListRepository;
        private readonly IMapper _mapper;

        public GetTodoListQueryHandler(ITodoListRepository todoListRepository, IMapper mapper)
        {
            _todoListRepository = todoListRepository;
            _mapper = mapper;
        }

        public async Task<TodoListDto> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            var data = await _todoListRepository.GetByIdAsync(request.Id);
            return _mapper.Map<TodoListDto>(data);
        }
    }
}
