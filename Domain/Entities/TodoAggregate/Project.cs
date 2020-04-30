using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.TodoAggregate
{
    public class Project //ValueObject
    {
        public string Name { get; private set; }

        public string Description { get; private set; }


        private Project() { }

        public Project(string name, string description)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Name = name;
            Description = description;
        }
    }
}
