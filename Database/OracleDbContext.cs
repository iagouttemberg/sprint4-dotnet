using Database.Mappings;
using Database.Models;
using Microsoft.EntityFrameworkCore;
namespace Database
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new FeedbackMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
