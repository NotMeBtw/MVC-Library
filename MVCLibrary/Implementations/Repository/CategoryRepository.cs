using MVCLibrary.IRepository;
using MVCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCLibrary.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MVCLIbraryContext _dbcontext;

        public CategoryRepository(MVCLIbraryContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool AddNewCategory(Category category)
        {
            try
            {
                _dbcontext.Entry(category).State = EntityState.Added;
                _dbcontext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                return _dbcontext.Category.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Category GetCategoryById(int id)
        {
            try
            {
                return _dbcontext.Category.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}