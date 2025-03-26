﻿using System.ComponentModel.DataAnnotations;

namespace EShop.Web.Models.Domain
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? ProductDescription { get; set; }
        [Required]
        public string? ProductImage { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]
        public double Rating { get; set; }
        public virtual ICollection<ProductInShoppingCart>? AllShoppingCarts { get; set; }
    }
}
