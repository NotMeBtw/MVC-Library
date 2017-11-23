using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLibrary.Models
{
    public class Queue
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Book Book { get; set; }
    }
}