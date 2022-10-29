namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataModel.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataModel.DB context)
        {
            SqlParameter name = new SqlParameter("name", "MyName");
            context.Database.ExecuteSqlCommand("update BookDescriptions set Title=@name", name);
        }
    }
}
