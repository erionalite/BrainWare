using System;
using System.Linq;
using Web.Infrastructure;
using Web.Models;

namespace Web.Repositories
{
    public class CompanyRepository :ICompanyRepository
    {
        private readonly IOrderContext _orderContext;
        public CompanyRepository(IOrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public CompanyEntity GetCompany(int companyId)
        {

            var company = _orderContext.Companies.Where(c => c.company_id == companyId).FirstOrDefault();
            if (company == null)
            {
                throw new  Exception("Could not find company with id :"+companyId);
            }

            return company;
        }
    }
}