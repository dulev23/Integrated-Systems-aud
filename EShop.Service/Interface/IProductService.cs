using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Domain.DomainModels;
using EShop.Domain.DTO;

namespace EShop.Service.Interface
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product? GetById(Guid Id);
        Product Add(Product product);
        Product DeleteById(Guid id);
        Product Update(Product product);
        Product Insert(Product product);
        AddToCartDTO GetSelectedShoppingCartProduct(Guid id);
        void AddProductToShoppingCart(Guid id, Guid userId, int quantity);
    }
}
