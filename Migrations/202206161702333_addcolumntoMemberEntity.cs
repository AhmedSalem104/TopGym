namespace TopGym_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumntoMemberEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Start_Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Members", "End_Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Members", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Members", "End_Date");
            DropColumn("dbo.Members", "Start_Date");
        }
    }
}
