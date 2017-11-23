using MVCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibrary.ViewModels
{
    public class AddBookViewModel
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get;set; }


    }
}