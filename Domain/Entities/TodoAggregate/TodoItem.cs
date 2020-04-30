using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.TodoAggregate
{
    public class TodoItem : BaseEntity, IAggregateRoot
    {
        private TodoItem()
        {

        }

        public TodoItem(string title, string note, PriorityLevel priority, bool done, DateTime? reminder)
        {
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.Null(priority, nameof(priority));
            Title = title;
            Note = note;
            Priority = priority;
            Done = done;
            Reminder = reminder;
        }


        public string Title { get; set; }

        public string Note { get; set; }

        public bool Done { get; set; }

        public DateTime? Reminder { get; set; }

        public PriorityLevel Priority { get; set; }


        public int ListId { get; set; }
        public TodoList List { get; set; }


        public void Update(string title, string note, PriorityLevel priority, bool done, DateTime? reminder)
        {
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.Null(priority, nameof(priority));
            Title = title;
            Note = note;
            Priority = priority;
            Done = done;
            Reminder = reminder;
        }
    }
}
