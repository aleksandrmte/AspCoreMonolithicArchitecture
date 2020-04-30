using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Entities.TodoAggregate
{
    public class TodoList : BaseEntity, IAggregateRoot
    {
        private TodoList()
        {
            
        }

        public TodoList(string title, string color, Project project, List<TodoItem> todoItems)
        {
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.NullOrEmpty(color, nameof(color));
            Guard.Against.Null(project, nameof(project));
            Title = title;
            Color = color;
            Project = project;
            _todoItems = todoItems;
        }

        public string Title { get; private set; }

        public string Color { get; private set; }

        public Project Project { get; private set; }


        private readonly List<TodoItem> _todoItems = new List<TodoItem>();
        public IReadOnlyCollection<TodoItem> TodoItems => _todoItems.AsReadOnly();

        public void Update(string title, string color, Project project)
        {
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.NullOrEmpty(color, nameof(color));
            Guard.Against.Null(project, nameof(project));
            Title = title;
            Color = color;
            Project = project;
        }
    }
}
