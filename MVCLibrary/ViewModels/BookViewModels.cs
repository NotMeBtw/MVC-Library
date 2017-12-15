using MVCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLibrary.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public bool Available { get; set; }

    }
}