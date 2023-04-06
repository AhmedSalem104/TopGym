namespace TopGym_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnInEntityMemberdiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "SubscriptionPriceDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "SubscriptionPriceDiscount");
        }
    }
}
