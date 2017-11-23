using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLibrary.Models
{
    public class Book
    {

        public int Id { get; set; }

        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Display(Name = "Numer ISBN")]
        public string ISBN { get; set; }

        [Display(Name = "Wypożyczona")]
        public bool Available { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<File> File { get; set; }

        public virtual ICollection<Tag> Tag { get; set; }
    }
}