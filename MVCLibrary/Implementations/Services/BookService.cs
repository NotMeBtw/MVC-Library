using MVCLibrary.Abstract.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLibrary.ViewModels;
using MVCLibrary.IRepository;
using MVCLibrary.Models;

namespace MVCLibrary.Implementations.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public CartBookViewModel GetBookViewModel(Cart cart)
        {
            var cartBookViewModel = new CartBookViewModel();
            cartBookViewModel.cart = cart;
            try
            {
                var books = _bookRepository.GetAllBoks();
                if (books == null) return cartBookViewModel;

                foreach (var item in books)
                {
                    cartBookViewModel.BookViewModels.Add(
                        new BookViewModel
                        {
                            Id = item.Id,
                            Author = item.Author,
                            Title = item.Title,
                            ISBN = item.ISBN,
                            Available = item.Available
                        }
                    );
                }
                return cartBookViewModel;
            }
            catch
            {
                return cartBookViewModel;
            }
        }
    }
}