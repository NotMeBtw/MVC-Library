using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLibrary.Models
{
    public class Cart
    {

        public List<Book> books { get; set; }

        public Cart()
        {
            books = new List<Book>();
        }

        public bool addNewBook(Book b)
        {
            books.Add(b);

            return true;
        }

    }
}