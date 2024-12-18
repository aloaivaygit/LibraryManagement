using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            ViewData["Title"] = "Dashboard";

            return View();
        }
        public IActionResult ManageBook()
        {
            ViewData["Title"] = "Manage Books";

            return View();
        }
        public IActionResult ManageUser()
        {
            ViewData["Title"] = "Manage Users";

            return View();
        }
    }
}
