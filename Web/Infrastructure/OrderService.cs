using System.Collections.Generic;
using System.Linq;

namespace Web.Infrastructure
{
    using System;
    using System.Data;
    using Models;

    public class OrderService : IOrderService
    {
        private readonly IDatabase _database;
        private readonly IOrderContext _orderContext;
        public OrderService(IDatabase database,IOrderContext orderContext)
        {
            _database = database;
            _orderContext = orderContext;
        }

        public List<Order> GetOrdersForCompany(int CompanyId)
        {
            
            var company = _orderContext.Companies.Where(c => c.company_id == CompanyId).FirstOrDefault();
            var values = company.Orders.Select( order => new Order
            {
                CompanyName = order.Company?.Name,
                Description = order.Description,
                OrderId = order.Order_Id,
                OrderProducts = getOrderProducts(order)
            }).ToList<Order>();
           
            foreach (var order in values)
            {
                foreach (var orderproduct in order.OrderProducts)
                {
                    order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
                }
            }

            return values;
        }

        private List<OrderProduct> getOrderProducts(OrderEntity order)
        {
            return order.OrderProducts.Select(orderProduct => new OrderProduct()
            {
                OrderId = orderProduct.OrderId,
                ProductId = orderProduct.ProductId,
                Price = orderProduct.Price,
                Quantity = orderProduct.Quantity,
                Product = new Product()
                {
                    Name = orderProduct.Product.Name,
                    Price = orderProduct.Product.Price
                }
            }).ToList();
        }
    }
}