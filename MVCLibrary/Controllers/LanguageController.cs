using MVCLibrary.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibrary.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageService _language;

        public LanguageController(ILanguageService languageService)
        {
            _language = languageService;
        }

        // GET: Language
        public ActionResult Change(String language)
        {
            Response.Cookies.Add(_language.Change(language));

            return RedirectToAction("Index", "Home");
        }
    }
}