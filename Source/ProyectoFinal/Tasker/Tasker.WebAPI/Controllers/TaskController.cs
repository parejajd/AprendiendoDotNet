using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasker.Models;
using Tasker.Services;

namespace Tasker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            //Consultar todas las tareas
            List<MyTask> tareas = _taskRepository.Tasks.Select(x => new MyTask
            {
                MyTaskId = x.MyTaskId,
                Name = x.Name,
                Description = x.Description,
                CreationDate = x.CreationDate,
                ModificationDate = x.ModificationDate,
                DueDate = x.DueDate,
                IsCompleted = x.IsCompleted,
                CompletedDate = x.CompletedDate,
                ProjectId = x.ProjectId,
                Project = new Project { ProjectName = x.Project.ProjectName },
                CreatedBy = new Person { FirstName = x.CreatedBy.FirstName, LastName = x.CreatedBy.LastName }
            }).ToList();

            return Ok(tareas);
        }
    }
}