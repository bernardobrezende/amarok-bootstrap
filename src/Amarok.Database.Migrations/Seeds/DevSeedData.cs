using FluentMigrator;
using System;

namespace Amarok.Database.Migrations.Seeds
{
    [Profile("Development")]
    public class DevSeedData : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Feature")
                .Row(new { Name = "Login", IsActive = true })
                .Row(new { Name = "SalesReport", IsActive = false })
                .Row(new { Name = "AuthorizeUsers", IsActive = true });
        }

        public override void Down() { }
    }
}
