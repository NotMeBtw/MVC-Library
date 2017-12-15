using MVCLibrary.Abstract.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLibrary.Models;
using System.Data.Entity;

namespace MVCLibrary.Implementations.Repository
{
    public class LendRepository : ILendRepository
    {
        private readonly MVCLIbraryContext _dbcontext;

        public LendRepository(MVCLIbraryContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool AddLend(Lend l)
        {
            try
            {
                _dbcontext.Entry(l).State = EntityState.Added;
                _dbcontext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}