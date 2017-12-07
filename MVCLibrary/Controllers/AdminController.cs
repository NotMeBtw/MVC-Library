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

        [System.Web.Mvc.HttpGet]
        public ActionResult AddBook() => View(_adminService.GetAddBookVM());
        
        [System.Web.Mvc.HttpPost]
        public ActionResult AddBook([FromBody]AddBookViewModel b)
        {
            _adminService.AddNewBook(b);

           return RedirectToAction("Index");
        }

        // GET: Admin/AddAuthor
        public ActionResult AddAuthor()
        {
            return View();
        }
    }
}
