using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Web.Models;


namespace Web.Infrastructure
{
    public class OrderContext : DbContext, IOrderContext
    {
        public OrderContext() : base("Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = BrainWAre; Integrated Security = SSPI; AttachDBFilename=E:\\Development\\BrainWare\\Web\\App_Data\\BrainWare.mdf")
        {
        }

        public IEnumerable<CompanyEntity> Companies
        {
            get { return DbCompanies.AsEnumerable(); }
        }
        public DbSet<CompanyEntity> DbCompanies { get;set; }     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProductEntity>().HasKey(s => new {s.OrderId, s.ProductId});
           
        }
    }
}