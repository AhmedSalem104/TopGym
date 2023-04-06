namespace TopGym_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addQRCodeEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QRCodeModels",
                c => new
                    {
                        QrId = c.Int(nullable: false, identity: true),
                        QRCodeText = c.String(),
                    })
                .PrimaryKey(t => t.QrId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QRCodeModels");
        }
    }
}
