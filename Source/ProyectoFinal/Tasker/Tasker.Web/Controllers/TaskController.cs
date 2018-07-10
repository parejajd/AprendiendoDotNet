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

        public TaskController(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        public IActionResult Index()
        {
            //Obtenga el listado de tareas
            // SELECT * FROM MyTask
            var taskList = this._taskRepository.Tasks;

            //Enviamos los datos a la Vista
            return View(taskList);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(MyTask task)
        {
            try
            {
                if (this._taskRepository.Add(task))
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

        public IActionResult Edit(int id)
        {
            //SELECT TOP 1 * FROM MyTask WHERE MyTaskId=id
            var task = this._taskRepository.Tasks.FirstOrDefault(x => x.MyTaskId == id);

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