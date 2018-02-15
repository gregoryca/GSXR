namespace GSXRWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Model_Motorcycle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MotorCycles", "Wheelbase", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MotorCycles", "Wheelbase", c => c.Int(nullable: false));
        }
    }
}
