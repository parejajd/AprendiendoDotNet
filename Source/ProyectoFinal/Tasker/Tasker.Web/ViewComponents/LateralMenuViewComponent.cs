using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasker.Services;
using Microsoft.EntityFrameworkCore;

namespace Tasker.Web.ViewComponents
{
    public class LateralMenuViewComponent : ViewComponent
    {
        private readonly ITaskRepository _taskRepository;

        public LateralMenuViewComponent(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var projectList = _taskRepository.Projects;
            return View(projectList);
        }
    }
}
