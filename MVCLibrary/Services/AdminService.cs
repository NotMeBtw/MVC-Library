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

        public AdminService(ICategoryRepository categoryRepository, IBookRepository bookRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
        }

        public bool AddNewBook(AddBookViewModel addBookVM)
        {
            if (addBookVM == null)
                return false;

            var category = _categoryRepository.GetCategoryById(int.Parse(addBookVM.SelectedCategoryId));

            if (category == null)
                return false;

            var book = new Book()
            {
                Author = addBookVM.Author,
                Title = addBookVM.Title,
                ISBN = addBookVM.ISBN,
                Category = category
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