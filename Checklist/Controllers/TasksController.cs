using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Checklist.Models;
using Checklist.Business;

namespace Checklist.Controllers
{
    public class TasksController : Controller
    {
        private checklistEntities checkList = new checklistEntities();
        TasksBusiness taskBusiness = new TasksBusiness();

        // GET: Tasks
        public ActionResult ListTasks()
        {
            return View(checkList.tasks.OrderBy(a => a.IdTask).ToList());
        }
        
        [HttpPost]
        public ActionResult NewTask(tasks newTask)
        {
            taskBusiness.NewTask(newTask);

            return Json(newTask, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult EditTask(tasks editTask)
        {
            taskBusiness.ChangeStatusTask(editTask);

            return Json(editTask, JsonRequestBehavior.AllowGet);
        }
    }
}