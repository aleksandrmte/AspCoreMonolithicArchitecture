using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.TodoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(TodoList.TodoItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(t => t.Project, p =>
            {
                p.WithOwner();

                p.Property(f => f.Name)
                    .HasMaxLength(60)
                    .IsRequired();
            });

            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Color)
                .IsRequired();
        }
    }
}
