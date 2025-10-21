using CrudJWT.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudJWT.Context
{
    public class CrudContext : DbContext
    {
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<ClientModel> Clients { get; set; }

        public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(builder.Configuration["Jwt:Key"]);
            base.OnConfiguring(options);
        }
    }
}
