using CrudJWT.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudJWT.Context
{
    public class CrudContext : DbContext
    {
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<ClientModel> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=database.sqlite");
            base.OnConfiguring(options);
        }
    }
}
