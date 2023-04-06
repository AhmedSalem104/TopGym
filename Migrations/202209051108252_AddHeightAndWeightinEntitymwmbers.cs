namespace TopGym_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeightAndWeightinEntitymwmbers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Height", c => c.String(nullable: false));
            AddColumn("dbo.Members", "Weight", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Weight");
            DropColumn("dbo.Members", "Height");
        }
    }
}
