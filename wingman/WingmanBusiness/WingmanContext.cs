using Microsoft.EntityFrameworkCore;
using System;


namespace WingmanBusiness.Models  //mPerholtz - not sure bout this namespace yet.
{
    public class WingmanContext : DbContext
    {        
        public string ConnectionString { get; set; }

        public WingmanContext(DbContextOptions options) : base(options)
        {         
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set;  }

        // mPerholtz - "borrowed from Rick Strahl Albumn viewer "
        // public DbSet<Album> Albums { get; set; }
        // public DbSet<Artist> Artists { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {         
            base.OnModelCreating(builder);
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    if (optionsBuilder.IsConfigured)
        //        return;

        //    // Auto configuration
        //    ConnectionString = Configuration.GetValue<string>("Data:AlbumViewer:ConnectionString");
        //    optionsBuilder.UseSqlServer(ConnectionString);
        //}

    }
}