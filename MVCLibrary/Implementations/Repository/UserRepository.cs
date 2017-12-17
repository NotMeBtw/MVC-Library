using MVCLibrary.Abstract.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLibrary.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace MVCLibrary.Implementations.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MVCLIbraryContext _dbcontext;
        public UserRepository(MVCLIbraryContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<User> GetClients()
        {
            //toodo
            try
            {
                var roleStore = new RoleStore<IdentityRole>(_dbcontext);
                var roleMngr = new RoleManager<IdentityRole>(roleStore);

                var roles = roleMngr.Roles.ToList();

                var role = roles.FirstOrDefault(r => r.Name == "Client");

                return _dbcontext.User.Where(u=>u.Roles==role).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
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