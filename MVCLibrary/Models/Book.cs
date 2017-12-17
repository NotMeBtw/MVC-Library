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

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public bool Available { get; set; }

        public string Tags { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Lend> Borrows { get; set; }

        public virtual ICollection<File> Files { get; set; }

        public virtual ICollection<Queue> Queues { get; set; }

    }
}