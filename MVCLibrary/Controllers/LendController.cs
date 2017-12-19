using MVCLibrary.Abstract.IRepository;
using MVCLibrary.IRepository;
using MVCLibrary.ViewModels;
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
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public LendController(ILendRepository lendRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _lendRepository = lendRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }



        // GET: Lend
        public ActionResult Index()
        {
            var lends = _lendRepository.GetALLLends();
            var lendViewModels = new List<LendViewModel>();
            foreach (var item in lends)
            {
                var book = _bookRepository.GetBookById(item.IdBook);
                var user = _userRepository.GetUserById(item.IdUser);
                lendViewModels.Add(
                    new LendViewModel
                    {
                        Author=book.Author,
                        Title=book.Title,
                        ISBN=book.ISBN,
                        State=item.State,
                        DateBorrowed=item.DateBorrowed,
                        DateReturn=item.DateReturn,
                        Name=user.Name,
                        Surname=user.Surname,
                        Id=item.Id
                    });
            }
            return View(lendViewModels);
        }
    }
}