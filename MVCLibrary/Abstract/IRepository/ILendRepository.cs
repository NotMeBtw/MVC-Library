using MVCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLibrary.Abstract.IRepository
{
    public interface ILendRepository
    {

        bool AddLend(Lend l);

        IEnumerable<Lend> GetALLLends();
    }
}
