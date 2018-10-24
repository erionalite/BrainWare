using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure;
using Web.Models;
using Web.Repositories;

namespace Tests.ServicesTest
{
    [TestClass]
    public class OrderServiceTest
    {
        [TestMethod]
        public void FindCompany_expectEmpty()
        {
            var mockCompanyRepository = MockRepository.GenerateStub<ICompanyRepository>();
            mockCompanyRepository.Stub(x => x.GetCompany(Arg<int>.Is.Anything)).Return(null);
            var orderService = new OrderService(mockCompanyRepository);
            var result = orderService.GetOrdersForCompany(0);
            Assert.IsTrue(!result.Any());
        }
        [TestMethod]
        public void FindCompany_expectNotEmpty()
        {
            var mockCompanyRepository = MockRepository.GenerateStub<ICompanyRepository>();
            mockCompanyRepository.Stub(x => x.GetCompany(Arg<int>.Is.Anything)).Return(new CompanyEntity()
            {
                company_id = 0,
                Name = "test",
                Orders = new List<OrderEntity>()
                {
                    new OrderEntity()
                    {
                        CompanyEntity = new CompanyEntity()
                        {
                            company_id = 1,
                            Name = "testCompany"
                        },
                        CompanyId = 1,
                        Description = "testDescription",
                        Order_Id = 2,
                        OrderProducts = new List<OrderProductEntity>()
                        {
                            new OrderProductEntity()
                            {
                                OrderId = 2,
                                Price = 22,
                                Quantity = 1,
                                Product = new ProductEntity()
                                {
                                    Name = "Test Product",
                                    Price = 33
                                }
                            }
                        }


                    }
                }
            });
            var orderService = new OrderService(mockCompanyRepository);
            var result = orderService.GetOrdersForCompany(0);
            Assert.IsTrue(result.Any());
        }

    }
}
