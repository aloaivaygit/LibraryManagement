using System.Diagnostics;
using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookContext _context;



        public HomeController(ILogger<HomeController> logger, BookContext context)
        {
            _logger = logger;
            _context = context;

        }
        public IActionResult Index()
        {
            var carouselItems = _context.Carousel
            .Where(c => c.IsActive)
            .OrderBy(c => c.Order)
            .ToList();

            var books = _context.Book.ToList();

            var categories = _context.Category.ToList();

            ViewBag.Categories = categories;
            ViewBag.Books = books;
            ViewBag.Carousels = carouselItems;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult OnGetPartial()
        {

            return PartialView("_NavBarPartial");
        }
    }
}
