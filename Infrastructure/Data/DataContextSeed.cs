using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.TodoAggregate;
using Domain.Enums;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public static class DataContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }

        public static async Task SeedSampleDataAsync(DataContext context)
        {
            // Seed, if necessary
            if (!context.TodoLists.Any())
            {
                context.TodoLists.Add(new TodoList("List 1", "red", new Project("Project 1", "description"), new List<TodoItem>
                    {
                        new TodoItem("Task 1", "task 1 note", PriorityLevel.Medium, false, null),
                        new TodoItem("Task 2", "task 2 note", PriorityLevel.High, false, null)
                    })
                );

                await context.SaveChangesAsync();
            }
        }
    }
}
