using MVCLibrary.Abstract.IRepository;
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

        private readonly ILendRepository _lendRepository;

        private readonly IUserRepository _userRepository;

        public CartService(IBookRepository bookRepository, ILendRepository lendRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _lendRepository = lendRepository;
            _userRepository = userRepository;
        }

        public bool AddBookToCart(Cart cart, int id)
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

        public bool ClearCart(Cart cart)
        {
            try
            {
                cart.books.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LendBooks(Cart cart)
        {
            try
            {
                var user = _userRepository.GetUserByEmail(HttpContext.Current.User.Identity.Name);

                foreach (var item in cart.books)
                {
                    if (item.Available == true)
                    {
                        var lend = new Lend
                        {
                            Book = item,
                            User = user,
                            DateBorrowed = DateTime.Now,
                            State="Wypożyczona",
                            DateReturn = DateTime.Now.AddDays(14)
                        };
                        _lendRepository.AddLend(lend);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}