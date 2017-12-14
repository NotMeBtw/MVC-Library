using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLibrary.ViewModels
{
    public class CategoryViewModel
    {
        public string Name { get; set; }

        [Display(Name="Z rodziny")]
        public string ParrentName { get; set; }
    }
}