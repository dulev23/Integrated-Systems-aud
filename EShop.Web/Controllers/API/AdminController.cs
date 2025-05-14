using EShop.Domain.DomainModels;
using EShop.Domain.Identity;
using EShop.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EShop.Domain.DTO;

namespace EShop.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<EShopApplicationUser> _userManager;

        public AdminController(IOrderService orderService, UserManager<EShopApplicationUser> userManager)
        {
            this._orderService = orderService;
            this._userManager = userManager;
        }

        [HttpGet("action")]
        public List<Order> GetAllOrders()
        {
            return this._orderService.GetAllOrders();
        }

        [HttpPost("action")]
        public Order GetOrderDetails(Guid Id)
        {
            return this._orderService.GetOrderDetails(Id);
        }

        [HttpPost("action")]
        public bool ImportAllUsers(List<UserRegistrationDTO> models)
        {
            bool status = true;
            foreach (UserRegistrationDTO item in models)
            {
                var userCheck = _userManager.FindByEmailAsync(item.Email).Result;
                if (userCheck != null)
                {
                    var user = new EShopApplicationUser
                    {
                        FirstName = "Test Name",
                        LastName = "Test LastName",
                        UserName = item.Email,
                        NormalizedUserName = item.Email.ToUpper(),
                        Email = item.Email,
                        EmailConfirmed = true,
                        UserCart = new ShoppingCart()
                    };
                    var result = _userManager.CreateAsync(user, item.Password).Result;
                    status = status & result.Succeeded;
                } else
                {
                    continue;
                }
            }
            return status;
        }
        
    }
}