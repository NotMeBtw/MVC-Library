using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        private readonly MVCLIbraryContext _dbcontext;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminController(IAdminService adminService, MVCLIbraryContext dbcontext, ApplicationSignInManager signInManager, ApplicationUserManager userManager)
        {
            _adminService = adminService;
            _dbcontext = dbcontext;
            _signInManager = signInManager;
            _userManager = userManager;
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
            if (ModelState.IsValid && _adminService.AddNewBook(b))
            {
                return RedirectToAction("Index", "Book");
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
            if (ModelState.IsValid && _adminService.AddNewCategory(categoryVM))
            {
               return RedirectToAction("Index", "Category");
            }
            else
            {
                return View(_adminService.GetAddCategoryVM());
            }
        }

        public  ActionResult  GetClients()
        {


            var roleStore = new RoleStore<IdentityRole>(_dbcontext);
            var roleMngr = new RoleManager<IdentityRole>(roleStore);

            var roles = roleMngr.Roles.ToList();

            var role = roles.FirstOrDefault(r => r.Name == "Client");

            var users = _dbcontext.User.Where(u => u.Roles.Any(r => r.RoleId == role.Id));


            return View(users);
        }
    }
}
