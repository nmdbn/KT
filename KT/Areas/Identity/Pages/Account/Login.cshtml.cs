using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KT.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<IdentityUser> signInManager,
                          UserManager<IdentityUser> userManager,
                          ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string MaSV { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(Input.MaSV);
                if (user != null)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect("~/");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByNameAsync(Input.MaSV);
        //        if (user != null)
        //        {
        //            var result = await _signInManager.PasswordSignInAsync(user.UserName, "DummyPassword", isPersistent: false, lockoutOnFailure: false);
        //            if (result.Succeeded)
        //            {
        //                _logger.LogInformation("User logged in.");
        //                return LocalRedirect("~/");
        //            }
        //            else
        //            {
        //                _logger.LogWarning("Login attempt failed.");
        //            }
        //        }
        //        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //    }

        //    return Page();
        //}

    }
}
