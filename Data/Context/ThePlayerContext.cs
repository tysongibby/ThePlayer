using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Context.EntityConfiguration;
using static System.Net.Mime.MediaTypeNames;
using Data.Models;

namespace Data.Context
{
    public class ThePlayerContext : DbContext
    {
        public IConfiguration Configuration { get; }
        //public DbContextOptions<ThePlayerContext> Options { get; }

        public ThePlayerContext() { }

        public ThePlayerContext(IConfiguration configuration, DbContextOptions<ThePlayerContext> options) : base(options)
        {
            Configuration = configuration;
            //Options = options;
        }

        public virtual DbSet<AudioFile> AudioFiles { get; set; }
        public virtual DbSet<SongGenre> SongGenres { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<AudioFile>(new AudioFileConfig());
            modelBuilder.ApplyConfiguration<SongGenre>(new SongGenreConfig());
            modelBuilder.ApplyConfiguration<Artist>(new ArtistConfig());
            modelBuilder.ApplyConfiguration<Album>(new AlbumConfig());
            modelBuilder.ApplyConfiguration<Song>(new SongConfig());
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    //  https://www.tektutorialshub.com/entity-framework-core/ef-core-dbcontext/
        //    services.AddDbContext<ThePlayerContext>(options => options.UseSqlite(Configuration.GetConnectionString("ThePlayerDb")));
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // https://csharp.hotexamples.com/examples/-/DbContextOptionsBuilder/-/php-dbcontextoptionsbuilder-class-examples.html
            base.OnConfiguring(optionsBuilder);

        }
    }
}
