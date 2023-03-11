using BakeryShop_Razor.Data;
using BakeryShop_Razor.Model;
using BakeryShop_Razor.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BakeryShop_Razor.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly BakeryDbContext _Db;
        [BindProperty]
        public User User { get; set; }
        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager
            , BakeryDbContext Db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _Db = Db;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var cart = new Cart();
                var user = new CustomUser { Email = User.Email , UserName = User.Email, Cart = cart};
                cart.UserId = user.Id;
                var result = await _userManager.CreateAsync(user,User.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("/Index");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return Page();
        }
    }
}
