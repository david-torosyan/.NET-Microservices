using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.ShoppingCartAPI.Models
{
    public class CartHeader
    {
        [Key]
        public int CartHeaderId { get; set; }
        public string? UserId { get; set;}
        public string? CouponCode { get; set;}

        // Do not add in database because it is working dynamicly
        [NotMapped]
        public double Dicount { get; set;}
        [NotMapped]
        public double CartTotal { get; set;}
    }
}
