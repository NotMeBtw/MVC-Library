using MVCLibrary.Abstract.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLibrary.ViewModels;
using MVCLibrary.IRepository;

namespace MVCLibrary.Implementations.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookViewModel> GetBookViewModel()
        {
            var bookViewModels = new List<BookViewModel>();

            try
            {
                var books = _bookRepository.GetAllBoks();
                if (books == null) return bookViewModels;

                foreach (var item in books)
                {
                    bookViewModels.Add(
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
                return bookViewModels;
            }
            catch
            {
                return bookViewModels;
            }
        }
    }
}