using ElectronicShop.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShop.Controllers
{
    public class OrderController : Controller
    {
        // GET: OrderController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authenticate]

        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
