using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AspProjesi.Models
{
    public class ContextApp:DbContext
    {
        protected readonly IConfiguration Configuration;
        public ContextApp(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("webapi"));
        }
        public DbSet<userinfo> Userinfo { get; set; }   
    }
}
