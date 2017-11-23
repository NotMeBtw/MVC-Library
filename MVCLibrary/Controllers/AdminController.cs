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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/AddBook
        public ActionResult AddBook()
        {
            return View();
        }

        // GET: Admin/AddAuthor
        public ActionResult AddAuthor()
        {
            return View();
        }
    }
}
