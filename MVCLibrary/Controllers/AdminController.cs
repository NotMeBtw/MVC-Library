using MVCLibrary.IServices;
using MVCLibrary.Models;
using MVCLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MVCLibrary.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public ActionResult Index()
        {
            return View();
        }
        [System.Web.Http.Authorize(Roles = "Worker,Admin")]
        [System.Web.Mvc.HttpGet]
        public ActionResult AddBook() => View(_adminService.GetAddBookVM());

        [System.Web.Http.Authorize(Roles = "Worker,Admin")]
        [System.Web.Mvc.HttpPost]
        public ActionResult AddBook([FromBody]AddBookViewModel b)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddNewBook(b);

                return RedirectToAction("Index","Book");
            }
            else
            {
                return View(_adminService.GetAddBookVM());
            }
        }

        [System.Web.Http.Authorize(Roles = "Worker,Admin")]
        [System.Web.Mvc.HttpGet]
        public ActionResult AddCategory()
        {
            return View(_adminService.GetAddCategoryVM());
        }

        [System.Web.Http.Authorize(Roles = "Worker,Admin")]
        [System.Web.Mvc.HttpPost]
        public ActionResult AddCategory(AddCategoryViewModel categoryVM) 
        {
            if (ModelState.IsValid)
            {
                _adminService.AddNewCategory(categoryVM);

                return RedirectToAction("Index","Category");
            }
            else
            {
                return View(_adminService.GetAddCategoryVM());
            }
        }
    }
}
