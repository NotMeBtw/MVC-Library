using MVCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLibrary.IRepository
{
    public interface IBookRepository
    {
        bool AddBook(Book book);
        IEnumerable<Book> GetAllBoks();
        Book GetBookById(int id);
    }
}
