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


        public ActionResult ClearCart(Cart cart)
        {
            if (_cartService.ClearCart(cart))
            {
                return RedirectToAction("Index","Book");
            }
            else
            {
                return RedirectToAction("Index", "Book");
            }
        }

        public ActionResult LendBooks(Cart cart)
        {
            if (_cartService.LendBooks(cart))
            {
                return RedirectToAction("Index", "Book");
            }
            else
            {
                return RedirectToAction("Index", "Book");
            }
        }

        public ActionResult RemoveBook(Cart cart, int id)
        {
            if (_cartService.RemoveBook(cart, id))
            {
                return RedirectToAction("Index", "Book");
            }
            else
            {
                return RedirectToAction("Index", "Book");
            }
        }
    }
}