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
        private  ApplicationUserManager _userManager;

        public UserRepository(MVCLIbraryContext dbcontext, ApplicationUserManager userManager)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
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

                return _userManager.Users.Where(u => u.Roles.Any(r => r.RoleId == role.Id)).ToList();
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

        public User GetUserById(string id)
        {

            try
            {
                return _dbcontext.User.FirstOrDefault(u => u.Id == id);
            }
            catch
            {
                return null;
            }
        }
    }
}