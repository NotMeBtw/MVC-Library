using MVCLibrary.IServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace MVCLibrary.Services
{
    public class LanguageService : ILanguageService
    {
        public HttpCookie Change(String language)
        {
            if (language != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = language;

            return cookie;
        }
    }
}