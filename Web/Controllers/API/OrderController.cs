using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Web.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;
    using Models;
    using Web.Models.Dto;

    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> GetOrders(int id = 1)
        {
            return _orderService.GetOrdersForCompany(id).ToList();
        }
    }
}
