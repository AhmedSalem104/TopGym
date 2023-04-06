namespace TopGym_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeightAndWeightinEntitymwmbersadneditinprocedure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "MemberWeight", c => c.String(nullable: false));
            DropColumn("dbo.Members", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Weight", c => c.String(nullable: false));
            DropColumn("dbo.Members", "MemberWeight");
        }
    }
}
