using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.TodoLists.Interfaces;
using ApplicationCore.TodoLists.Specifications;
using FluentValidation;

namespace ApplicationCore.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
    {
        private readonly ITodoListRepository _todoListRepository;

        public CreateTodoListCommandValidator(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            var data = await _todoListRepository.ListAsync(new TodoListGetByNameSpecification(title));
            return !data.Any();

        }
    }
}
