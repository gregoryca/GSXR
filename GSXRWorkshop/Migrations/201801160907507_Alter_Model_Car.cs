namespace GSXRWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Model_Car : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Year", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Year");
        }
    }
}
