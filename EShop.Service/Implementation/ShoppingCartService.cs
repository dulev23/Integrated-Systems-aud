using EShop.Domain.DomainModels;
using EShop.Domain.DTO;
using EShop.Repository.Interface;
using EShop.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<ProductInShoppingCart> _productInShoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<ProductInOrder> _productInOrderRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IRepository<ProductInShoppingCart> productInShoppingCartRepository, IRepository<Order> orderRepository, IRepository<ProductInOrder> productInOrderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _orderRepository = orderRepository;
            _productInOrderRepository = productInOrderRepository;
        }

        public bool OrderProducts(string userId)
        {
            var shoppingCart = _shoppingCartRepository.Get(selector: x => x,
               predicate: x => x.OwnerId == userId,
               include: x => x.Include(y => y.ProductInShoppingCarts).ThenInclude(z => z.Product));

            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                Owner = shoppingCart.Owner,
                OwnerId = userId,
                Total = 0.0
            };

            _orderRepository.Insert(newOrder);

            var productsInOrder = shoppingCart.ProductInShoppingCarts.Select(x => new ProductInOrder
            {
                OrderId = newOrder.Id,
                Order = newOrder,
                ProductId = x.ProductId,
                OrderedProduct = x.Product,
                Quantity = x.Quantity
            });

            double total = 0.0;

            foreach (var product in productsInOrder)
            {
                total += product.OrderedProduct.Price * product.Quantity;
                _productInOrderRepository.Insert(product);
            }

            newOrder.Total = total;
            _orderRepository.Update(newOrder);

            shoppingCart.ProductInShoppingCarts.Clear();
            _shoppingCartRepository.Update(shoppingCart);

            return true;
        }

        public ShoppingCartDTO GetByUserIdWithIncludedProducts(Guid userId)
        {
            var userCart = _shoppingCartRepository.Get(selector: x => x,
                                                       predicate: x => x.OwnerId == userId.ToString(),
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

        public void DeleteProductFromShoppingCart(Guid productInShoppingCartId)
        {

            var productInShoppingCart = _productInShoppingCartRepository.Get(selector: x => x,
                                                                             predicate: x => x.Id.Equals(productInShoppingCartId));

            if (productInShoppingCart == null)
            {
                throw new Exception("Product in shopping cart not found");
            }

            _productInShoppingCartRepository.Remove(productInShoppingCart);
        }
    }
}
