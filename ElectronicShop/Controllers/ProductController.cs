using ElectronicShop.App_Start;
using ElectronicShop.Filters;
using ElectronicShopBL.IBL;
using ElectronicShopBL.ViewModels;
using ElectronicShopRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace ElectronicShop.Controllers
{
   
    public class ProductController : Controller
    {
        IBussinseContext bussinseContext = UnityConfig.Container.Resolve<IBussinseContext>();

        // GET: ProductController
        public IActionResult Index()
        {
            var vm = ProductVM.getProducts(bussinseContext);
            return View(vm);
        }

        // GET: ProductController/Details/5
        public IActionResult Details(int id)
        {
            var result = ProductVM.getProduct(bussinseContext, id);
            return View(result);
          
      
        }

        // GET: ProductController/Create
        [Authenticate]
        [AuthorizeAdmin]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [Authenticate]
        [AuthorizeAdmin]
        public IActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var result = ProductVM.addProduct(bussinseContext, productVM);
                if (result==null)
                {
                    return View(productVM);
                }
                else
                {
                    return Redirect("Index");
                }
            }
            return View(productVM);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
