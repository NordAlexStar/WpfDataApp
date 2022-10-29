using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DB : DbContext
    {
        public DbSet<BookDescription> BookDescriptions { get; set; }
        public DbSet<Printed> Printeds { get; set; }
        public DbSet<Author> Authors { get; set; }
     //   public DbSet<SeriaElement> SeriaElements { get; set; }
        public DbSet<Ganre> Ganres { get; set; }
      //  public DbSet<Seria> Serias { get; set; }

       public IQueryable<BookDescription> BooksWithAuthor => BookDescriptions.Where(x => x.Author.Id == 1);

        public DB() : base(@"Data Source=(LocalDb)\LocalDb;Initial Catalog=Books;Integrated Security=SSPI")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB, DataModel.Migrations.Configuration>());
        }

        public DB(string ConnectionString): base(ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Printed>().
                Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("Printeds");
                });

            modelBuilder.Entity<BookDescription>().
               Map(m =>
               {
                   m.MapInheritedProperties();
                   m.ToTable("BookDescriptions");
               });


            //    modelBuilder.Entity<SeriaElement>().HasRequired(x => x.Book).WithOptional(x => x.IsMemberOfSeria);

        }
    }
}
