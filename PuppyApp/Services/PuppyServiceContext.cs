using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PuppyApp
{
    public class PuppyServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PuppyServiceContext() : base("name=PuppyServiceContext")
        {
            // Debug Help
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Models.UserProfile> UserProfiles { get; set; }

        public DbSet<Models.Pet> Pets { get; set; }

        public DbSet<Models.HistoryPoint> HistoryPoints { get; set; }

        public DbSet<Models.Desease> Deseases { get; set; }

        public System.Data.Entity.DbSet<PuppyApp.Models.Owner> Owners { get; set; }
    }
}
