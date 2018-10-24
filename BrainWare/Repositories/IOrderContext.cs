using System.Data.Entity;
using Web.Models;

namespace Web.Infrastructure
{
    public interface IOrderContext
    {
        DbSet<CompanyEntity> Companies { get; set; }
        
    }
}