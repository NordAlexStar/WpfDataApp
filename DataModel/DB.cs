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
        
        public DB(): base("Data Source=(LocalDb)\\LocalDb;Initial Catalog=Books;Integrated Security=SSPI")
        { }
    }
}
