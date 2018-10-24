using System.Collections.Generic;
using Web.Models.Dto;

namespace Web.Infrastructure
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrdersForCompany(int CompanyId);
    }
}