using EShop.Domain.DomainModels;
using EShop.Domain.DTO;
using EShop.Repository.Interface;
using EShop.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public ShoppingCartDTO GetByUserIdWithIncludedProducts(Guid userId)
        {
            var userCart = _shoppingCartRepository.Get(selector: x => x,
                                                       predicate: x => x.OwnerId.Equals(userId.ToString()),
                                                       include: x => x.Include(z => z.ProductInShoppingCarts).ThenInclude(m => m.Product));

            var allProducts = userCart.ProductInShoppingCarts.ToList();

            var allProductPrices = allProducts.Select(z => new
            {
                ProductPrice = z.Product.Price,
                Quantity = z.Quantity
            }).ToList();

            double totalPrice = 0.0;

            foreach(var item in allProductPrices)
            {
                totalPrice += item.Quantity * item.ProductPrice;
            }

            ShoppingCartDTO model = new ShoppingCartDTO
            {
                Products = allProducts,
                totalPrice = totalPrice
            };

            return model;
        }

        public ShoppingCart? GetUserById(Guid userId)
        {
            return _shoppingCartRepository.Get(selector: x => x,
                                               predicate: x => x.OwnerId.Equals(userId.ToString()));
        }
    }
}
