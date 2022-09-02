using FPTBook.Areas.Identity.Data;
using FPTBook.Data;
using FPTBook.Models;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FPTBook.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<FPTBookUser> _userManager;

        private readonly FPTBookContext _context;

        public AdminController(
          UserManager<FPTBookUser> userManager, FPTBookContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Users()
        {
            var usersWithPermission = _userManager.Users;

            return View(usersWithPermission);
        }
    }
}