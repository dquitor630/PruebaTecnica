using Microsoft.EntityFrameworkCore;
using PruebaTenica.Shared;

namespace PruebaTenica.Server.Db
{
    public class FilmDbContext : DbContext, IDbContextScoped, IDbContextSingleton, IDbContextTransient
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<PlayList> PlayList { get; set; }
        public DbSet<PlayListFilms> PlayListFilms { get; set; }

        public string DbId { get; }

        public FilmDbContext(DbContextOptions options) : base(options){
            DbId = Guid.NewGuid().ToString();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Film;Trusted_Connection=True;Encrypt=False;");
            }
        }
    }

}
