using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Models;
using Tasker.Services;
using Tasker.DataAccess;

namespace Tasker.Web.DataAccess
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TaskerDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TaskerDbContext>>()))
            {
                if (context.Tasks.Any())
                {
                    return;
                }
                else
                {
                    var person = new Person
                    {
                        FirstName = "Juan David",
                        LastName = "Pareja Soto",
                        Email = "parejajd@outlook.com",
                        PhoneNumber = "3214914812"
                    };
                    context.Person.Add(person);
                    context.SaveChanges();

                    var anotherPerson = new Person
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "nn@outlook.com",
                        PhoneNumber = "3588887441"
                    };
                    context.Person.Add(anotherPerson);
                    context.SaveChanges();

                    var project = new Project
                    {
                        ProjectName = "Curso .NET"
                    };
                    context.Projects.Add(project);
                    context.SaveChanges();


                    context.Tasks.AddRange(
                        new MyTask
                        {
                            Name = "Preparar mas café",
                            Description = "Es necesario comprar mas café para el proximo sabado",
                            DueDate = new DateTime(2018, 8, 15),
                            ProjectId = project.ProjectId,
                            CreatedById = person.PersonId
                        },
                        new MyTask
                        {
                            Name = "Preparar Pan",
                            Description = "Es necesario comprar mas pan para el proximo sabado",
                            DueDate = new DateTime(2018, 8, 15),
                            ProjectId = project.ProjectId,
                            CreatedById = person.PersonId
                        }
                        );

                    context.SaveChanges();


                    foreach (var tasks in context.Tasks)
                    {
                        context.PersonTasks.Add(new PersonTasks
                        {
                            MyTaskId = tasks.MyTaskId,
                            PersonId = anotherPerson.PersonId
                        });
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
