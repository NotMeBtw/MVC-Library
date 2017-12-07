using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVCLibrary.IServices
{
    public interface ILanguageService
    {

        HttpCookie Change(String language);
    }
}
