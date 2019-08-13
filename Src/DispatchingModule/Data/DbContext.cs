using DispatchingModule.Model;
using Microsoft.EntityFrameworkCore;

namespace DispatchingModule.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext() : base()
        {

        }
        private const string connectionString = "Server=WKSTI-19\\SQLEXPRESS;Initial Catalog=Monitoring;Integrated Security=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Capture> Capture { get; set; }

    }


}
