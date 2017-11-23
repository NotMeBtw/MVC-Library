using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLibrary.Models
{
    public class Lend
    {
        public int Id { get; set; }

        [Display(Name = "Data wypożyczenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{:0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateBorrowed { get; set; }

        [Display(Name = "Data oddania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{:0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateReturn { get; set; }

        [Display(Name = "Stan wypożyczenia")]
        public string State { get; set; }

        public virtual User User { get; set; }

        public virtual Book Book { get; set; }
    }
}