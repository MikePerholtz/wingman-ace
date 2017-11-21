using Microsoft.EntityFrameworkCore;
using System;


namespace WingmanFleet.Models  //mPerholtz - not sure bout this namespace yet.
{
    public class WingmanContext : DbContext
    {        
        public string ConnectionString { get; set; }

        
        //mPerholtz below boilerplate constructor is used when EFCore looks for the connection string 
        //to use from the "options" passed in from Startup.cs
        public WingmanContext(DbContextOptions options) : base(options)
        {  

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set;  }

        //protected override void OnConfiguring 
        // mPerholtz - "borrowed from Rick Strahl Albumn viewer "
        // public DbSet<Album> Albums { get; set; }
        // public DbSet<Artist> Artists { get; set; }

        
        
        // mperholtz - Rick Strahl used the following in his code
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