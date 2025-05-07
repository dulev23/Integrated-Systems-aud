using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Domain.DomainModels;
using EShop.Domain.DTO;

namespace EShop.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCart? GetUserById(Guid userId);
        ShoppingCartDTO GetByUserIdWithIncludedProducts(Guid userId);
        void DeleteProductFromShoppingCart(Guid productInShoppingCartId);
    }
}
