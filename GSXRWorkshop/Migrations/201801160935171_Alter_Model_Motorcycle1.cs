namespace GSXRWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Model_Motorcycle1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MotorCycles", "Year", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MotorCycles", "Year");
        }
    }
}
