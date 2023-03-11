using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakeryShop_Razor.Model
{
    public class Cart //Useless Model To make codeing more complicating
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public CustomUser? CustomUser { get; set; }
        public string? Order { get; set; }
    }
}
