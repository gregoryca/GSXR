namespace GSXRWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Model_Motorcycle2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MotorCycles", "Displacement", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MotorCycles", "Displacement", c => c.Int(nullable: false));
        }
    }
}
