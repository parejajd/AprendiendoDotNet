using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasker.Web.DataAccess.Repository;
using Tasker.Web.Models;

namespace Tasker.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IPeopleRepository _peopleRepository;

        public TaskController(ITaskRepository taskRepository, IPeopleRepository peopleRepository)
        {
            this._taskRepository = taskRepository;
            this._peopleRepository = peopleRepository;
        }

        public IActionResult Index(int id)
        {
            //Obtenga el listado de tareas
            // SELECT * FROM MyTask WHERE ProjectId=id
            List<MyTask> taskList = this._taskRepository.Tasks.Where(x => x.ProjectId == id).ToList();

            //Enviamos los datos a la Vista
            return View(taskList);
        }

        public IActionResult New()
        {
            ViewData["ProjectList"] = this._taskRepository.Projects.ToList();
            ViewData["PersonList"] = this._peopleRepository.Person.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult New(MyTask task)
        {
            try
            {
                task.CreatedById = 1; //Temporal mientras implementamos el login
                if (this._taskRepository.Add(task))
                {
                    return RedirectToAction("Index", new { id = task.ProjectId });
                }
                else
                {
                    ViewData["Error"] = "No se guardaron los datos consulte con el admin";
                    return View();
                }
            }
            catch (Exception)
            {
                ViewData["Error"] = "No se guardaron los datos consulte con el admin";
                return View();
            }

        }

        public IActionResult Edit(int id)
        {
            //SELECT TOP 1 * FROM MyTask WHERE MyTaskId=id
            var task = this._taskRepository.Tasks.FirstOrDefault(x => x.MyTaskId == id);
            ViewData["ProjectList"] = this._taskRepository.Projects.ToList();
            ViewData["PersonList"] = this._peopleRepository.Person.ToList();
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(MyTask task)
        {
            try
            {
                if (this._taskRepository.Update(task.MyTaskId, task))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Error"] = "No se guardaron los datos consulte con el admin";
                    return View();
                }
            }
            catch (Exception)
            {
                ViewData["Error"] = "No se guardaron los datos consulte con el admin";
                return View();
            }

        }

        public IActionResult View(int id)
        {
            var task = this._taskRepository.Tasks.FirstOrDefault(x => x.MyTaskId == id);

            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = this._taskRepository.Tasks.FirstOrDefault(x => x.MyTaskId == id);

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(MyTask task)
        {
            try
            {
                if (this._taskRepository.Delete(task.MyTaskId))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Error"] = "No se guardaron los datos consulte con el admin";
                    return View();
                }
            }
            catch (Exception)
            {
                ViewData["Error"] = "No se guardaron los datos consulte con el admin";
                return View();
            }
        }
    }
}