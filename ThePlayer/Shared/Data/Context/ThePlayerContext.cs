﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThePlayer.Shared.Data.Models;
using ThePlayer.Shared.Context.EntityConfigurations;
using static System.Net.Mime.MediaTypeNames;

namespace ThePlayer.Shared.Data.Context
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<AudioFile>(new AudioFileConfig());
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