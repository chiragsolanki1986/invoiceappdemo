
using CompanyInvoiceApp.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyInvoiceApp.Api.Data
{
    public class CompanyInvoiceAppDbContext : DbContext
    {

        public CompanyInvoiceAppDbContext(DbContextOptions<CompanyInvoiceAppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
    }
}