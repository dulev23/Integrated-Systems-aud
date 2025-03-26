using System.ComponentModel.DataAnnotations;

namespace EShop.Domain.DomainModels
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string? ImageURL { get; set; }
        [Required]
        public double Rating { get; set; }

        public virtual ICollection<ProductInShoppingCart>? ProductInShoppingCarts { get; set; }
    }
}