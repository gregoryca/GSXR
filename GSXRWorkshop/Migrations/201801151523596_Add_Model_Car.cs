namespace GSXRWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Model_Car : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        Displacement = c.String(),
                        Wheelbase = c.String(),
                    })
                .PrimaryKey(t => t.CarId);
            
            AddColumn("dbo.Repairs", "CarId", c => c.Int(nullable: false));
            CreateIndex("dbo.Repairs", "CarId");
            AddForeignKey("dbo.Repairs", "CarId", "dbo.Cars", "CarId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "CarId", "dbo.Cars");
            DropIndex("dbo.Repairs", new[] { "CarId" });
            DropColumn("dbo.Repairs", "CarId");
            DropTable("dbo.Cars");
        }
    }
}
