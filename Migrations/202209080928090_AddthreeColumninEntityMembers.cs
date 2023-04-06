namespace TopGym_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddthreeColumninEntityMembers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "PhoneNumber", c => c.String());
            AddColumn("dbo.Members", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Members", "GenderType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "GenderType");
            DropColumn("dbo.Members", "IsDelete");
            DropColumn("dbo.Members", "PhoneNumber");
        }
    }
}
