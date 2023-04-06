namespace TopGym_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumntoMemberEntity3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "SubscriptionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "SubscriptionId");
            AddForeignKey("dbo.Members", "SubscriptionId", "dbo.Subscriptions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "SubscriptionId", "dbo.Subscriptions");
            DropIndex("dbo.Members", new[] { "SubscriptionId" });
            DropColumn("dbo.Members", "SubscriptionId");
        }
    }
}
