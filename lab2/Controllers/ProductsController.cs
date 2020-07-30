using lab2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2.Controllers
{
    public class ProductsController : Controller
    {
		private ApplicationDbContext _context;

		public ProductsController()
		{
			_context = new ApplicationDbContext();
		}

		// GET: Products
		[HttpGet]
		public ActionResult Index()
		{
			var list = _context.Products.Include(m => m.Category).ToList();
			return View(list);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Product product)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Create");
			}
			_context.Products.Add(product);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);

			if (productInDb == null)
			{
				return HttpNotFound();
			}

			_context.Products.Remove(productInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);

			if (productInDb == null)
			{
				return HttpNotFound();
			}

			return View(productInDb);
		}

		[HttpPost]
		public ActionResult Edit(Product product)
		{
			var productInDb = _context.Products.SingleOrDefault(p => p.Id == product.Id);

			if (productInDb == null)
			{
				return HttpNotFound();
			}

			productInDb.Name = product.Name;
			productInDb.Price = product.Price;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}