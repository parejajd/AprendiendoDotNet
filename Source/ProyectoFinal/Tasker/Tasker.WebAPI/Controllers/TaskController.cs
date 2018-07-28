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
        [Route("[action]/{projectId?}")]
        public async Task<IActionResult> Tasks(int projectId = 0)
        {
            //Consultar todas las tareas
            List<MyTask> tareas = new List<MyTask>();
            if (projectId == 0)
            {
                tareas = _taskRepository.Tasks;
            }
            else
            {
                tareas = _taskRepository.Tasks
                    .Where(x => x.ProjectId == projectId).ToList();
            }

            return Ok(tareas
                    .Select(x => new MyTask
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
                        Project = new Project { ProjectId = x.ProjectId, ProjectName = x.Project.ProjectName },
                        CreatedBy = new Person { FirstName = x.CreatedBy.FirstName, LastName = x.CreatedBy.LastName }
                    }).ToList());
        }

        [HttpGet]
        [Route("[action]/{projectId?}")]
        public async Task<IActionResult> Projects(int projectId = 0)
        {
            //Si el projectId es CERO, retonar todos los proyectos
            //Si no es cero, retornar el que tenga el id especificado
            List<Project> proyectos = _taskRepository.Projects
                   .Where(x => projectId == 0 || x.ProjectId == projectId)
                   .Select(x => new Project
                   {
                       ProjectId = x.ProjectId,
                       ProjectName = x.ProjectName
                   }).ToList();
            return Ok(proyectos);
        }

    }
}