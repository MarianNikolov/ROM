namespace ROM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Restaurants", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Restaurants", new[] { "Name" });
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
