using MVCLibrary.Abstract.IServices;
using MVCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Book
        public ActionResult Index(Cart cart)
        {
            return View(_bookService.GetBookViewModel(cart));
        }

        public ActionResult Search()
        {
            return View();
        }



    }
}