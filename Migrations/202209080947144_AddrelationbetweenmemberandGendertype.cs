namespace TopGym_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddrelationbetweenmemberandGendertype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenderName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Members", "GenderTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "GenderTypeId");
            AddForeignKey("dbo.Members", "GenderTypeId", "dbo.GenderTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "GenderTypeId", "dbo.GenderTypes");
            DropIndex("dbo.Members", new[] { "GenderTypeId" });
            DropColumn("dbo.Members", "GenderTypeId");
            DropTable("dbo.GenderTypes");
        }
    }
}
