namespace TopGym_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumntoMemberEntity4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subscriptions", "SubscriptionName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscriptions", "SubscriptionName", c => c.Int(nullable: false));
        }
    }
}
