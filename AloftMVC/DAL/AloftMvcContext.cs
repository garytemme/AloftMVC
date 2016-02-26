using AloftMVC.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AloftMVC.DAL
{
    public class AloftMvcContext : DbContext
    {
        public AloftMvcContext() : base("umbracoDbDSN")
        {
        }

        public DbSet<ContactUs> ContactUs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //base.OnModelCreating(modelBuilder);
        }
    }
}