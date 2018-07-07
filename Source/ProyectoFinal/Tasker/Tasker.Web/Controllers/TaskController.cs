using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasker.Web.DataAccess;
using Tasker.Web.Models;

namespace Tasker.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskerDbContext _db;

        public TaskController(TaskerDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            //Obtenga el listado de tareas
            // SELECT * FROM MyTask
            var taskList = _db.Tasks.ToList();

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
            //SELECT Max(MyTaskId) FROM MyTaskId 
            int actualId = _db.Tasks.Max(x => x.MyTaskId);
            task.MyTaskId = actualId + 1;
            _db.Tasks.Add(task);
            try
            {
                if (_db.SaveChanges() > 0)
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
            var task = _db.Tasks.FirstOrDefault(x => x.MyTaskId == id);

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(MyTask task)
        {
            var oldTask = _db.Tasks.FirstOrDefault(x => x.MyTaskId == task.MyTaskId);

            //Solo voy a cambiar el nombre, ustedes pueden cambiar lo demas
            oldTask.Name = task.Name;
            oldTask.Description = task.Description;
            oldTask.DueDate = task.DueDate;
            oldTask.IsCompleted = task.IsCompleted;

            if (task.IsCompleted)
            {
                oldTask.CompletedDate = DateTime.Now;
            }

            oldTask.ModificationDate = DateTime.Now;

            try
            {
                if (_db.SaveChanges() > 0)
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
            var task = _db.Tasks.FirstOrDefault(x => x.MyTaskId == id);

            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = _db.Tasks.FirstOrDefault(x => x.MyTaskId == id);

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(MyTask task)
        {
            var deletingTask = _db.Tasks.FirstOrDefault(x => x.MyTaskId == task.MyTaskId);

            _db.Tasks.Remove(deletingTask);

            try
            {
                if (_db.SaveChanges() > 0)
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