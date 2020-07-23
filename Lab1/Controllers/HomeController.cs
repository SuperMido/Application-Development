using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult numberFromTo()
        {

            return View();
        }

        public ActionResult TodoList()
        {

            using (var db = new TaskDbContext())
            {
                var tasks = db.Tasks.ToList();

                return View(tasks);
            }
        }

    }
}