using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLibrary.Models
{
    public class Category
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Category RootCategory { get; set; }
    }
}