using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Text.Json;

namespace Movie.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<memebrshiptypes> memebrshiptypes { get; set; }
        public DbSet<Movies> movies { get; set; }
        string resourceName = "Models/Genre.json";
        string resourcemem = "Models/Mem.json";
        string resourcemovie = "Models/Movies.json";

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);


            string GenreJSon = System.IO.File.ReadAllText(resourceName);
            List<Genres>? genres = System.Text.Json.JsonSerializer.Deserialize<List<Genres>>(GenreJSon);

            foreach (Genres c in genres)
                model.Entity<Genres>()
                .HasData(c);

            string memJSon = System.IO.File.ReadAllText(resourcemem);
            List<memebrshiptypes>? memebrship = System.Text.Json.JsonSerializer.Deserialize<List<memebrshiptypes>>(memJSon);

            foreach (memebrshiptypes c in memebrship)
                model.Entity<memebrshiptypes>()
                .HasData(c);
            string movies= System.IO.File.ReadAllText(resourcemovie);
            List<Movies>? movie = System.Text.Json.JsonSerializer.Deserialize<List<Movies>>(movies);

            foreach (Movies c in movie)
                model.Entity<Movies>()
                .HasData(c);
        }

    }
}
