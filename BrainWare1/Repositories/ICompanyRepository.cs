using Web.Models;

namespace Web.Repositories
{
    public interface ICompanyRepository
    {
        CompanyEntity GetCompany(int compantyId);
    }
}