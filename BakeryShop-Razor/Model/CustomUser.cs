using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakeryShop_Razor.Model
{
    public class CustomUser : IdentityUser
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
