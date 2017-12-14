using MVCLibrary.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLibrary.Models;
using System.Data.Entity;

namespace MVCLibrary.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly MVCLIbraryContext _dbcontext;

        public BookRepository(MVCLIbraryContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool AddBook(Book book)
        {
            try
            {
                _dbcontext.Entry(book).State = EntityState.Added;
                _dbcontext.SaveChanges();

                return true;

            }catch
            {
                return false;
            }
        }

        public IEnumerable<Book> GetAllBoks()
        {
            try
            {
                return _dbcontext.Books.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}