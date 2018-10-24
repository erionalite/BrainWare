using System.Collections.Generic;
using System.Data.Entity;
using Web.Models;

namespace Web.Infrastructure
{
    public interface IOrderContext
    {
        IEnumerable<CompanyEntity> Companies { get; }
        
    }
}