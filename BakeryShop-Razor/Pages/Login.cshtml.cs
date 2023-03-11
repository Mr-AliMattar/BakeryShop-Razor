using BakeryShop_Razor.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BakeryShop_Razor.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        [BindProperty]
        public LoginUser User { get; set; }
        public LoginModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(User.Email, User.Password,
                    isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                  return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong Mail Or Password");
                    return Page();
                }
            }
            return Page();
        }
    }
}
