using BakeryShop_Razor.Data;
using BakeryShop_Razor.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace BakeryShop_Razor.Pages
{
    public class MyCartModel : PageModel
    {
        private readonly BakeryDbContext _context;
        public List<Product> products { get; set; } = new List<Product>();
        [BindProperty]
        [Display(Name = "Quantity")]
        public int OrderQuantity { get; set; }
        private IdentityUser User { get; set; }
        public MyCartModel(BakeryDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (id.Count() > 2)
                {
                    string[] x = id.Split('?');
                    string myUser = x[1];
                    string[] myOrder = x[0].Split();

                    string y = string.Empty; //Filter the duplicates
                    for (int i = 0; i < myOrder.Length; i++)
                    {
                        if (!y.Contains(myOrder[i]))
                        {
                            y += myOrder[i];
                        }
                    }

                    char[] z = y.ToCharArray();
                   
                    for (int i = 0; i < z.Length; i++)
                    {
                        products.Add(await _context.products.FindAsync(int.Parse(z[i].ToString())));
                    }
                    //Why did i even created a Cart? tbh I have no fucking idea xD
                    var user = await _context.Users.FirstAsync(u=> u.UserName == myUser);
                    User = user;
                    if (user != null)
                    {
                        var cart = await _context.Carts.FirstAsync(c=> c.UserId == user.Id);
                        if (cart != null)
                        {
                            cart.Order = x[0];
                        }                       
                    }
                }
            }
        }
        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var body = $@"Thank you, we have received your order!
                We will contact you if we have questions about your order.  Thanks!<br/>";

                var SmtpServer = "smtp-mail.outlook.com";
                var SmtpPort = 587;

                SmtpClient smtpClient = new SmtpClient(SmtpServer, SmtpPort);
                smtpClient.Credentials = new NetworkCredential
                {
                    UserName = "admin",
                    Password = "admin"
                };
                smtpClient.EnableSsl = false;
                try
                {
                    await smtpClient.SendMailAsync("sales@BakeryShop.com", User.Email, "New Order - BakeryShop", body);
                    RedirectToPage("OrderSuccessful");
                }
                catch { throw; }
                RedirectToPage("/MyCart");
            }
            RedirectToPage("/MyCart");
        }
    }
}
