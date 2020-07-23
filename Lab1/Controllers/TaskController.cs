using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class TaskController : Controller
    {
        [HttpPost]
        public ActionResult Create(Task task)
        {
            if (task == null)
            {
                return RedirectToAction("ToDoList", "Home");
            }

            using (var db = new TaskDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }

            return RedirectToAction("ToDoList", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ToDoList", "Home");
            }

            using (var db = new TaskDbContext())
            {
                var task = db.Tasks.Find(id);

                if (task == null)
                {
                    return RedirectToAction("ToDoList", "Home");
                }

                db.Tasks.Remove(task);
                db.SaveChanges();
            }

            return RedirectToAction("ToDoList", "Home");
        }

        //GET - EDIT
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ToDoList", "Home");
            }
            using (var db = new TaskDbContext())
            {
                var task = db.Tasks.Find(id);

                if (task == null)
                {
                    return RedirectToAction("ToDoList", "Home");
                }
                return View(task);
            }
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            if (task == null)
            {
                return RedirectToAction("ToDoList", "Home");
            }

            using (var db = new TaskDbContext())
            {
                db.Tasks.AddOrUpdate(task);
                db.SaveChanges();
            }

            return RedirectToAction("ToDoList", "Home");
        }
    }
}