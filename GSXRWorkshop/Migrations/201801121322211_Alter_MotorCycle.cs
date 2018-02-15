namespace GSXRWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_MotorCycle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MotorCycles", "Displacement", c => c.Int(nullable: false));
            DropColumn("dbo.MotorCycles", "Fault");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MotorCycles", "Fault", c => c.String());
            AlterColumn("dbo.MotorCycles", "Displacement", c => c.Double(nullable: false));
        }
    }
}
