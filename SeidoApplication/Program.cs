using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SeidoDemoDb;
using SeidoDemoModels;

namespace SeidoApplication
{
    class Program
    {
        private static DbContextOptionsBuilder<SeidoDemoDbContext> _optionsBuilder;
        static void Main(string[] args)
        {
            BuildOptions();

            SeedDataBase();
            QueryDatabaseAsync().Wait();
        }

        private static void BuildOptions()
        {
            _optionsBuilder = new DbContextOptionsBuilder<SeidoDemoDbContext>();


            Console.WriteLine($"DbConnections Directory: {DBConnection.DbConnectionsDirectory}");

            var connectionString = DBConnection.ConfigurationRoot.GetConnectionString("SQLite_seidodemo");
            if (!string.IsNullOrEmpty(connectionString))
                Console.WriteLine($"Connection string to Database: {connectionString}");
            else
            {
                Console.WriteLine($"Please copy the 'DbConnections.json' to this location");
                return;
            }


            _optionsBuilder.UseSqlite(connectionString);
        }



        private static void SeedDataBase()
        {
            using (var db = new SeidoDemoDbContext(_optionsBuilder.Options))
            {
                //Create some customers
                var necklaces = new List<Necklace>();
                for (int i = 0; i < 10; i++)
                {
                    necklaces.Add(new Necklace());
                }
                //Create some orders randomly linked to customers
                var rnd = new Random();
                var PList = new List<Pearl>();
                for (int i = 0; i < 5; i++)
                {
                    PList.Add(new Pearl(necklaces[rnd.Next(0, necklaces.Count)].NecklaceID));
                }

                //Add it to the Database
                necklaces.ForEach(cust => db.Necklaces.Add(cust));
                PList.ForEach(order => db.Pearl.Add(order));

                db.SaveChanges();
            }
        }
        private static async Task QueryDatabaseAsync()
        {
            using (var db = new SeidoDemoDbContext(_optionsBuilder.Options))
            {
                var cs = await db.Necklaces.CountAsync();
                var ps = await db.Pearl.CountAsync();

                Console.WriteLine($"Nr of Necklaces: {cs}");
                Console.WriteLine($"Nr of Pearl: {ps}");
            }
        }

    }
}
