using ElectronicShop.App_Start;
using ElectronicShopBL.IBL;
using ElectronicShopBL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Unity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        //private readonly IBussinseContext bussinseContext;
        IBussinseContext bussinseContext = UnityConfig.Container.Resolve<IBussinseContext>();
        //public CategoryController(IBussinseContext _bussinseContext)
        //{
        //    bussinseContext = _bussinseContext;
        //}
        public ActionResult Index()
        {
            var vm = CategoryVM.getCategories(bussinseContext);
            return View(vm);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        [HttpPost]
        public IActionResult Create(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                var result = CategoryVM.addCategory(bussinseContext, categoryVM);
                if (result == null)
                {
                    return View(categoryVM);
                }
                else
                {
                    return Redirect("Index");
                }
            }
            return View(categoryVM);
        }

        // POST: CategoryController/Create
        [HttpGet]
        public IActionResult Create()
        {
       
                return View();
            
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
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

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
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
