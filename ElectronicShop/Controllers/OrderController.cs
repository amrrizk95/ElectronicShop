using ElectronicShop.Filters;
using ElectronicShopBL.ViewModels;
using ElectronicShopRepository;
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
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: OrderController1
        [Authenticate]
      
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("CurrentUserId");
            var Role = HttpContext.Session.GetInt32("UserRole");
            var vm = OrderVM.getUserOrders(_unitOfWork, userId, Role);

            return View(vm);
        }

        // GET: OrderController1/Details/5
        public ActionResult Details(int id)
        {
           
            return View();
        }

        // GET: OrderController1/Create
        public ActionResult Create( int productId)
        {
            var vm= OrderVM.getOrderVM(_unitOfWork, productId);
            return View(vm);
        }

        // POST: OrderController1/Create
        [HttpPost]
        [Authenticate]

        public IActionResult Create(OrderVM vm)
        {
            var customerId = HttpContext.Session.GetInt32("CurrentUserId");
            if (ModelState.IsValid)
            {
                var result = OrderVM.addOrder(_unitOfWork, vm, customerId);
                return RedirectToAction("Index", "Order");
            }
            else
            {
                return View(vm);
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
