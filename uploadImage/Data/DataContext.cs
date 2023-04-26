using Microsoft.EntityFrameworkCore;
using System.Xml;
using uploadImage.Model;

namespace uploadImage.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
    }
}
