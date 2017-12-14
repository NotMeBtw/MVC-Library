using MVCLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLibrary.Abstract.IServices
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetCategories();

    }
}
