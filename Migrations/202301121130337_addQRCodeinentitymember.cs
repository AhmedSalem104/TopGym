namespace TopGym_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addQRCodeinentitymember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "QrCodemember", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "QrCodemember");
        }
    }
}
