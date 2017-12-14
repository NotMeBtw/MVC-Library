using MVCLibrary.Abstract.IServices;
using MVCLibrary.IRepository;
using MVCLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLibrary.Implementations.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRpository;

        public CategoryService(ICategoryRepository categoryRpository)
        {
            _categoryRpository = categoryRpository;
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            try
            {
                var categories = _categoryRpository.GetAllCategories();

                if (categories == null) return null;

                var categoriesVM = new List<CategoryViewModel>();

                foreach (var item in categories)
                {
                    var rootCategor = categories.FirstOrDefault(c => c.Id == item.RootCategoryId);

                    string name = string.Empty;

                    if (rootCategor != null)
                        name = rootCategor.Name;

                    categoriesVM.Add(new CategoryViewModel
                    {
                        Name = item.Name,
                        ParrentName = name
                    });
                }
                return categoriesVM;
            }
            catch
            {
                return null;
            }
        }
    }
}