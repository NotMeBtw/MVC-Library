using MVCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLibrary.IRepository
{
    public interface ICategoryRepository
    {

        IEnumerable<Category> GetAllCategories();
    }
}
