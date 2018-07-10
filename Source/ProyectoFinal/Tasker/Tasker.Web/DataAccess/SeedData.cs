using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Web.Models;

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
                    context.Tasks.AddRange(
                        new MyTask
                        {
                            Name = "Preparar mas café",
                            Description = "Es necesario comprar mas café para el proximo sabado",
                            DueDate = new DateTime(2018, 8, 15)
                        },
                        new MyTask
                        {
                            Name = "Preparar Pan",
                            Description = "Es necesario comprar mas pan para el proximo sabado",
                            DueDate = new DateTime(2018, 8, 15)
                        }
                        );

                    context.SaveChanges();
                }
            }
        }
    }
}
