using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DB: DbContext
    {
        public DbSet<BookDescription> BookDescriptions { get; set; }  
        public DbSet<Author> Authors { get; set; }
        
        public DB(): base(@"Data Source=(LocalDb)\LocalDb;Initial Catalog=Books;Integrated Security=SSPI")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB, DataModel.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
