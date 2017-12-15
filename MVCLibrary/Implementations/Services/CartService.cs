using MVCLibrary.Abstract.IServices;
using MVCLibrary.IRepository;
using MVCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLibrary.Implementations.Services
{
    public class CartService : ICartService
    {
        private readonly IBookRepository _bookRepository;

        public CartService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public bool AddBookToCart(Cart cart,int id)
        {
            try
            {
                var book = _bookRepository.GetBookById(id);

                if (book == null) return false;

                cart.books.Add(book);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}