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

        public DateTime DateBorrowed { get; set; }

        public DateTime DateReturn { get; set; }

        public string State { get; set; }
        public int IdBook { get; set; }
        public string IdUser { get; set; }
        public virtual User User { get; set; }

        public virtual Book Book { get; set; }
    }
}