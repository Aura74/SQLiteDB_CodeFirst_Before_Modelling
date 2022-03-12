using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using SeidoDemoModels;

namespace SeidoDemoDb
{
    public class SeidoDemoDbContext:DbContext
    {
        #region Uncomment to create the Data model
        public DbSet<Necklace> Necklaces { get; set; }
        public DbSet<Pearl> Pearl { get; set; }
        #endregion

        public SeidoDemoDbContext() { }
        public SeidoDemoDbContext(DbContextOptions options) : base(options)
        { }

        #region Uncomment to create the Data model

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = DBConnection.ConfigurationRoot.GetConnectionString("SQLite_seidodemo");
                optionsBuilder.UseSqlite(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        #endregion
    }
}
