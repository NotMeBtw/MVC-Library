using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLibrary.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }
}