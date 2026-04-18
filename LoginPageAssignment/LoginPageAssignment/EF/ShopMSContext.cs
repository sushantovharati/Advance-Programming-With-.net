using LoginPageAssignment.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace LoginPageAssignment.EF
{
    public class ShopMSContext : DbContext
    {
        public ShopMSContext(DbContextOptions<ShopMSContext> options)
: base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}