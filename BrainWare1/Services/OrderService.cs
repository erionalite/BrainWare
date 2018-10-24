using Web.Repositories;

namespace Web.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using Models;
    using Web.Models.Dto;

    public class OrderService : IOrderService
    {
        private readonly ICompanyRepository _companyRepository;
        public OrderService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IEnumerable<Order> GetOrdersForCompany(int companyId)
        {
            
            var company = _companyRepository.GetCompany(companyId);

            var values = company.Orders.Select(order => new Order
            {
                CompanyName = order.CompanyEntity?.Name,
                Description = order.Description,
                OrderId = order.Order_Id,
                OrderProducts = getOrderProducts(order)
            }).ToList();
           
            foreach (var order in values)
            {
                foreach (var orderproduct in order.OrderProducts)
                {
                    order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
                }
            }

            return values;
        }

        private IEnumerable<OrderProduct> getOrderProducts(OrderEntity order)
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
            });
        }
    }
}