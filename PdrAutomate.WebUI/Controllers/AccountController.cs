using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PdrAutomate.WebUI.DataAccess.Abstract;
using PdrAutomate.WebUI.DataAccess.Concrete.EntityFramework;
using PdrAutomate.WebUI.IdentityCore;
using PdrAutomate.WebUI.Models;

namespace PdrAutomate.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;

        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returlUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model,string returnUrl)
        {
            var user = await userManager.FindByNameAsync(model.StudentSchoolId);
            var role = await userManager.GetRolesAsync(user);

            if (user != null)
            {
                if (role.FirstOrDefault() == "admin")
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "Presentations/Index");
                    }
                }
                else if(role.FirstOrDefault() == "teacher")
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "Teacher/Index");
                    }
                }
            }
            ModelState.AddModelError(nameof(model.StudentSchoolId), "Hatalı okul numarası");

            return View(model);
        }

        public async Task<IActionResult> Logout(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}