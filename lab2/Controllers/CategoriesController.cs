using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2.Controllers
{
    public class CategoriesController : Controller
    {
		private ApplicationDbContext _context;

        public CategoriesController()
        {
			_context = new ApplicationDbContext();
		}
		// GET: Categories
		[HttpGet]
		public ActionResult Index()
		{
			var categories = _context.Categories.ToList();
			return View(categories);
		}

		[HttpGet]
		public ActionResult Create()
		{
			// To be implemented

			return View();
		}

		[HttpPost]
		public ActionResult Create(Category category)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Create");
			}
			_context.Categories.Add(category);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var CategoryInDb = _context.Categories.SingleOrDefault(p => p.Id == id);

			if (CategoryInDb == null)
			{
				return HttpNotFound();
			}

			_context.Categories.Remove(CategoryInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var CategoryInDb = _context.Categories.SingleOrDefault(p => p.Id == id);

			if (CategoryInDb == null)
			{
				return HttpNotFound();
			}

			return View(CategoryInDb);
		}

		[HttpPost]
		public ActionResult Edit(Category category)
		{
			var CategoryInDb = _context.Categories.SingleOrDefault(p => p.Id == category.Id);

			if (CategoryInDb == null)
			{
				return HttpNotFound();
			}

			CategoryInDb.Name = category.Name;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}