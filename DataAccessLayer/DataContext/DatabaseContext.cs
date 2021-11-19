using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataContext
{
    // DbContext is a pre-build class that allows us to interact with our database
    public class DatabaseContext : DbContext
    {
        // Initiating a database connection with its entities
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                optionsBuilder.UseSqlServer(settings.sqlConnectionString);
                databaseOptions = optionsBuilder.Options;
            }
            // DbContextOptionsBuilder is a pre-build API that allows us to configure the connection to our database
            public DbContextOptionsBuilder<DatabaseContext> optionsBuilder { get; set; }
            // DbContextOptions is a class that obtains our database information
            public DbContextOptions<DatabaseContext> databaseOptions { get; set; }
            // connection string
            private AppConfiguration settings { get; set; }
        }

        // making the OptionsBuild class accessible from other namespaces and classes
        public static OptionsBuild ops = new OptionsBuild();

        // constructor for the DbContext class
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }
        // DbSets
        public DbSet<Users> Users { get; set; }
        // prvite <> se za imeto na klasata sto ima vo nea properties,a vtoroto e imeto na Tabelata
        // public DbSet<Buses> Buses { get; set; }

    }
}
