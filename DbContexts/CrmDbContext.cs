using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReGenerationProjectAssignment_FundRaiser.DbContexts
{
    public class CrmDbContext : DbContext
    {
        /*public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Payment> Payments { get; set; }*/

        public CrmDbContext() { }
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
        {
        }

    }
}
