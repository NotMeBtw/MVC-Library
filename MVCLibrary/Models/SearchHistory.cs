using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLibrary.Models
{
    public class SearchHistory
    {

        public int Id { get; set; }

        [Display(Name = "Data wyszukiwania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{:0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SearchDate { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}