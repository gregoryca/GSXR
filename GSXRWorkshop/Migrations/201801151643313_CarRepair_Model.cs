namespace GSXRWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarRepair_Model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Repairs", "CarId", "dbo.Cars");
            DropIndex("dbo.Repairs", new[] { "CarId" });
            CreateTable(
                "dbo.CarRepairs",
                c => new
                    {
                        RepairId = c.Int(nullable: false, identity: true),
                        RepairName = c.String(),
                        Notes = c.String(nullable: false),
                        CarId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RepairId)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.EmployeeId);
            
            DropColumn("dbo.Repairs", "CarId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Repairs", "CarId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CarRepairs", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CarRepairs", "CarId", "dbo.Cars");
            DropIndex("dbo.CarRepairs", new[] { "EmployeeId" });
            DropIndex("dbo.CarRepairs", new[] { "CarId" });
            DropTable("dbo.CarRepairs");
            CreateIndex("dbo.Repairs", "CarId");
            AddForeignKey("dbo.Repairs", "CarId", "dbo.Cars", "CarId", cascadeDelete: true);
        }
    }
}
