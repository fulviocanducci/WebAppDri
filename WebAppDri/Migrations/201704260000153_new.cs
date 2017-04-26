namespace WebAppDri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kind",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                        KindId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("dbo.Kind", t => t.KindId)
                .Index(t => t.KindId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "KindId", "dbo.Kind");
            DropIndex("dbo.Product", new[] { "KindId" });
            DropTable("dbo.Product");
            DropTable("dbo.Kind");
        }
    }
}
