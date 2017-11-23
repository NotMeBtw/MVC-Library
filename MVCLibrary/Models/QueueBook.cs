using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLibrary.Models
{
    public class QueueBook
    {
        public int Id { get; set; }

        public ICollection<User> Users { get; set; }

        public Book Book { get; set; }

    }
}