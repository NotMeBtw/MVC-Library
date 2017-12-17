using MVCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLibrary.Abstract.IRepository
{
    public interface IUserRepository
    {

        User GetUserByEmail(string email);

        IEnumerable<User> GetClients();

    }
}
