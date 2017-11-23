using MVCLibrary.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibrary.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private readonly IAdminService _bookService;

        public AdminController(IAdminService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/AddBook
        public ActionResult AddBook() => View(_bookService.GetAddBookVM());
        

        // GET: Admin/AddAuthor
        public ActionResult AddAuthor()
        {
            return View();
        }
    }
}
