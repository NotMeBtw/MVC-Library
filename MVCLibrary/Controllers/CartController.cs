using MVCLibrary.Abstract.IServices;
using MVCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibrary.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public ActionResult Index(Cart cart)
        {
            return View(cart);
        }

        public ActionResult AddBookToCart(Cart cart, int id)
        {
            string url = this.Request.UrlReferrer.AbsolutePath;
            if (_cartService.AddBookToCart(cart, id))
            {
                return Redirect(url);
            }
            else
            {
                return Redirect(url);
            }
        }
    }
}