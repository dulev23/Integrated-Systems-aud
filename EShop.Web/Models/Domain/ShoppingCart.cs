using EShop.Web.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace EShop.Web.Models.Domain
{
    public class ShoppingCart
    {
        [Key]
        public Guid Id { get; set; }
        public string? OwnerId { get; set; }
        public EShopApplicationUser? Owner { get; set; }
        public virtual ICollection<ProductInShoppingCart>? AllProducts { get; set; }

    }
}
