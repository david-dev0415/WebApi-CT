namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ChangedDefaultColumnNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "FirstName", c => c.String());
            AddColumn("dbo.User", "LastName", c => c.String());
            // AddColumn("dbo.User", "DefaultPassword", c => c.Byte(nullable: false, defaultValue: 1));
        }

        public override void Down()
        {
            DropColumn("dbo.User", "LastName");
            DropColumn("dbo.User", "FirstName");
            DropColumn("dbo.User", "DefaultPassword");
        }
    }
}
