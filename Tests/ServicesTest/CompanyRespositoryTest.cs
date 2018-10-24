using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Web.Infrastructure;
using Web.Models;
using Web.Repositories;

namespace Tests.ServicesTest
{

    [TestClass]
    public class CompanyRespositoryTest
    {
        [TestMethod]
        public void FindCompany_expectNotEmpty()
        {
            var mockOrderContext = MockRepository.GenerateStub<IOrderContext>();
            
            mockOrderContext.Stub(x => x.Companies).Return(new CompanyEntity[] { new CompanyEntity()
            {
                company_id = 0,
                Name= "test"
            }});
            var companyRespository = new CompanyRepository(mockOrderContext);
            var companyEntity = companyRespository.GetCompany(0);
            Assert.IsTrue(companyEntity.Name == "test");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Could not find company with id :0")]
        public void FindCompany_expectNull()
        {
            var mockOrderContext = MockRepository.GenerateStub<IOrderContext>();
            mockOrderContext.Stub(x => x.Companies).Return(new CompanyEntity[] { new CompanyEntity()
            {
                company_id = 1,
                Name= "test"
            }});
            var companyRespository = new CompanyRepository(mockOrderContext);
            var companyEntity = companyRespository.GetCompany(0);
        }
    }
}
