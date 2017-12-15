using MVCLibrary.Abstract.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLibrary.Models;

namespace MVCLibrary.Implementations.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MVCLIbraryContext _dbcontext;

        public UserRepository(MVCLIbraryContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                return _dbcontext.User.FirstOrDefault(u => u.Email == email);
            }
            catch
            {
                return null;
            }
        }
    }
}