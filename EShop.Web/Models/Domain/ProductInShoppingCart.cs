using System.ComponentModel.DataAnnotations;

namespace EShop.Web.Models.Domain
{
    public class ProductInShoppingCart
    {
        [Key]
        public Guid Id { get; set; }
        public string? ProductId { get; set; }
        public Product? AddedProduct { get; set; }
        public string? ShoppingCartId { get; set; }
        public ShoppingCart? AddedShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
