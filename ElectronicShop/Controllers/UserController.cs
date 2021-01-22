using ElectronicShop.App_Start;
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
    public class UserController : Controller
    {
        IBussinseContext bussinseContext = UnityConfig.Container.Resolve<IBussinseContext>();
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                var user = UserVM.LoginUser(_unitOfWork, userVM);
                if (user == null)
                {
                    ViewBag.LoginError = true;
                    ViewBag.Message = "UserName or password is incorrect";
                    return View(userVM);
                }
                HttpContext.Session.SetInt32("CurrentUserId", user.id);
                HttpContext.Session.SetString("UserName", user.userName);
                HttpContext.Session.SetInt32("UserRole", user.role.Value);
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
