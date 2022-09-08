
using FPTBook.Areas.Identity.Data;
using FPTBook.Data;
using FPTBook.Models;
using FPTBook.ViewModels;
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

        [HttpGet]
        public IActionResult ResetPassword(string id)
        {
            var user = _userManager.GetUserId(User);
            if (user is null)
            {
                return NotFound();
            }

            var viewModel = new ResetPasswordViewModel
            {
                Id = id,
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return View();
            }

            return View();
        }

    }
}