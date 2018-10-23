using System.Collections.Generic;
using System.Linq;

namespace Web.Infrastructure
{
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

            // Get the orders
            var sql1 =
                "SELECT c.name, o.description, o.order_id FROM company c INNER JOIN [order] o on c.company_id=o.company_id";
            var result = _orderContext.Product.ToList();
            var result3 = _orderContext.Companies.Where(c => c.company_id == CompanyId).FirstOrDefault();
            var result2 = _orderContext.Orders.ToList();
            //var reader1 = _database.ExecuteReader(sql1);


            var company = _orderContext.Companies.Where(c => c.company_id == CompanyId).FirstOrDefault();
            var values = company.Orders.Select( order => new Order
            {
                CompanyName = order.Company?.Name,
                Description = order.Description,
                OrderId = order.Order_Id,
                OrderProducts = new List<OrderProduct>()
            }).ToList<Order>();
            //    new List<Order>();

            //while (reader1.Read())
            //{
            //    var record1 = (IDataRecord) reader1;

            //    values.Add(new Order()
            //    {
            //        CompanyName = record1.GetString(0),
            //        Description = record1.GetString(1),
            //        OrderId = record1.GetInt32(2),
            //        OrderProducts = new List<OrderProduct>()
            //    });

            //}

            //reader1.Close();

            //Get the order products
            var sql2 =
                "SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id";

            var reader2 = _database.ExecuteReader(sql2);

            var values2 = new List<OrderProduct>();

            while (reader2.Read())
            {
                var record2 = (IDataRecord)reader2;

                values2.Add(new OrderProduct()
                {
                    OrderId = record2.GetInt32(1),
                    ProductId = record2.GetInt32(2),
                    Price = record2.GetDecimal(0),
                    Quantity = record2.GetInt32(3),
                    Product = new Product()
                    {
                        Name = record2.GetString(4),
                        Price = record2.GetDecimal(5)
                    }
                });
             }

            reader2.Close();

            foreach (var order in values)
            {
                foreach (var orderproduct in values2)
                {
                    if (orderproduct.OrderId != order.OrderId)
                        continue;

                    order.OrderProducts.Add(orderproduct);
                    order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
                }
            }

            return values;
        }
    }
}