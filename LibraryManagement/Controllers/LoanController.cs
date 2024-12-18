using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;

namespace LibraryManagement.Controllers
{
    public class LoanController : Controller
    {

        private readonly BookContext _BookContext;

        public LoanController(BookContext bookContext)
        {
     
            _BookContext = bookContext;
        }
        public IActionResult Index()
        {
            var list = _BookContext.Loan.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Users = new SelectList(_BookContext.User.ToList(), "UserId", "UserName");
            ViewBag.Books = new SelectList(_BookContext.Book.ToList(), "BookId", "Title");

            return View();
        }
        [HttpPost]
        public IActionResult Create(Loan loan)
        {
            if (ModelState.IsValid)
            {
                if (loan.LoanDate == null)
                {
                    loan.LoanDate = DateTime.Now;
                }
                _BookContext.Loan.Add(loan);
                _BookContext.SaveChanges();

                TempData["SuccessMessage"] = "Created successfully!";

                return RedirectToAction("Index");
            }
            ViewBag.Users = new SelectList(_BookContext.Users.ToList(), "UserId", "UserName");
            ViewBag.Books = new SelectList(_BookContext.Book.ToList(), "BookId", "Title");

            return View(loan);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var loan = _BookContext.Loan.Find(id);
            if (loan == null)
            {
                return NotFound();
            }
            ViewBag.Users = new SelectList(_BookContext.User.ToList(), "UserId", "UserName");
            ViewBag.Books = new SelectList(_BookContext.Book.ToList(), "BookId", "Title");

            return View(loan);
        }

        [HttpPost]
        public IActionResult Edit(Loan loan)
        {
            if (ModelState.IsValid)
            {
                _BookContext.Loan.Update(loan);
                _BookContext.SaveChanges();
                TempData["SuccessMessage"] = "Updated successfully!";
                return RedirectToAction("Index");
            }
            ViewBag.Users = new SelectList(_BookContext.User.ToList(), "UserId", "UserName");
            ViewBag.Books = new SelectList(_BookContext.Book.ToList(), "BookId", "Title");

            return View(loan);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var loan = _BookContext.Loan.Find(id);
            if (loan == null)
            {
                return NotFound();
            }

            _BookContext.Loan.Remove(loan);
            _BookContext.SaveChanges();
            TempData["SuccessMessage"] = "Deleted successfully!";

            return RedirectToAction("Index");
        }
    }
}
