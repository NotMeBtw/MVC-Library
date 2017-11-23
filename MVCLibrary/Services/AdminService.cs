using MVCLibrary.IRepository;
using MVCLibrary.IServices;
using MVCLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibrary.Services
{
    public class AdminService : IAdminService
    {
        private readonly ICategoryRepository _categoryRepository;

        public AdminService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public AddBookViewModel GetAddBookVM()
        {
            try
            {
                var categoryList = _categoryRepository.GetAllCategories();

                if (categoryList == null)
                {
                    return null;
                }

                var categoryDropDownList = categoryList.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });

                return new AddBookViewModel
                {
                    CategoryList = categoryDropDownList
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}