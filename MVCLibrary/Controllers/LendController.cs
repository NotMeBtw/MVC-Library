using MVCLibrary.Abstract.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLibrary.Controllers
{
    public class LendController : Controller
    {
        private readonly ILendRepository _lendRepository;

        public LendController(ILendRepository lendRepository)
        {
            _lendRepository = lendRepository;
        }

        // GET: Lend
        public ActionResult Index()
        {
            return View(_lendRepository.GetALLLends());
        }
    }
}