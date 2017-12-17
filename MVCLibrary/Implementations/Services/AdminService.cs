using MVCLibrary.Abstract.IRepository;
using MVCLibrary.IRepository;
using MVCLibrary.IServices;
using MVCLibrary.Models;
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
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public AdminService(ICategoryRepository categoryRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public bool AddNewBook(AddBookViewModel model)
        {
            if (model == null)
                return false;

            var category = _categoryRepository.GetCategoryById(int.Parse(model.SelectedCategoryId));

            if (category == null)
                return false;


            var book = new Book()
            {
                Author = model.Author,
                Title = model.Title,
                ISBN = model.ISBN,
                Category = category,
                Tags=model.Tags,
                Available=true
            };

            try
            {
                _bookRepository.AddBook(book);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddNewCategory(AddCategoryViewModel addCategoryVM)
        {
            try
            {
                if (addCategoryVM == null)
                    return false;

                var category = new Category
                {
                    Name = addCategoryVM.Name
                };

                if (addCategoryVM.SelectedCategoryId != null)
                {
                    var rootCategory = _categoryRepository.GetCategoryById(int.Parse(addCategoryVM.SelectedCategoryId));
                    category.RootCategoryId = rootCategory.Id;
                }

                _categoryRepository.AddNewCategory(category);
                return true;
            }
            catch
            {
                return false;
            }
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

        public AddCategoryViewModel GetAddCategoryVM()
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

                return new AddCategoryViewModel
                {
                    CategoryList = categoryDropDownList
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<User> GetAllClients()
        {
            try
            {
               return _userRepository.GetClients();
            }
            catch
            {
                return null;
            }
        }
    }
}