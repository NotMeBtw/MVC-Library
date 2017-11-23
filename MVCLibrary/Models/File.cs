using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLibrary.Models
{
    public class File
    {

        public int Id { get; set; }

        public byte[] Content { get; set; }
    }
}