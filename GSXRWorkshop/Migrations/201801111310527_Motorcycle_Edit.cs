namespace GSXRWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Motorcycle_Edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Motorcycles", "MotorCycleName", c => c.String());
            AlterColumn("dbo.Motorcycles", "Displacement", c => c.Double(nullable: false));
            DropColumn("dbo.Motorcycles", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Motorcycles", "Name", c => c.String());
            AlterColumn("dbo.Motorcycles", "Displacement", c => c.Single(nullable: false));
            DropColumn("dbo.Motorcycles", "MotorCycleName");
        }
    }
}
