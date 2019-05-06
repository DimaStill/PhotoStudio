using PhotoStudio.Model;
using System.Data.Entity;

namespace PhotoStudio.Context
{
    class PhotoStudioContext : DbContext
    {
        public PhotoStudioContext()
            : base("DefaultConnection")
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
