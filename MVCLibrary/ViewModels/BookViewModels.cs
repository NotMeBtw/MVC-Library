using MVCLibrary.Models;
using MVCLibrary.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLibrary.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Display(Name = nameof(HomeTexts.Title), ResourceType = typeof(HomeTexts))]
        public string Title { get; set; }
        [Display(Name = nameof(HomeTexts.Author), ResourceType = typeof(HomeTexts))]
        public string Author { get; set; }

        public string ISBN { get; set; }
        [Display(Name = nameof(HomeTexts.Availability), ResourceType = typeof(HomeTexts))]
        public bool Available { get; set; }

    }
}