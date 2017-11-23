using MVCLibrary.IRepository;
using MVCLibrary.Models;
using System;
using System.Collections.Generic;
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
    }
}