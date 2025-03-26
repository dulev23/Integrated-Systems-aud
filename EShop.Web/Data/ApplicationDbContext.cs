using EShop.Web.Models.Domain;
using EShop.Web.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Web.Data;

public class ApplicationDbContext : IdentityDbContext<EShopApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
}
