using MVCLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibrary.ViewModels
{
    public class AddBookViewModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public string SelectedCategoryId { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get;set; }

    }
}