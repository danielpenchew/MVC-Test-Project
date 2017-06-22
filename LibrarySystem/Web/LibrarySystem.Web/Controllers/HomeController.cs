using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using LibrarySystem.Data.Services.Contracts;
using LibrarySystem.Web.Models.Author;
using System.Linq;
using System.Web.Mvc;

namespace LibrarySystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorServices authorServices;

        public HomeController(IAuthorServices authorServices)
        {
            Guard.WhenArgument(authorServices, "authorServices").IsNull().Throw();

            this.authorServices = authorServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var authors = authorServices.GetAllAuthors().ProjectTo<AuthorViewModel>().ToList();

            ViewBag.Authors = new SelectList(authors, "Id", "FirstName", "LastName");

            return View();
        }
    }
}