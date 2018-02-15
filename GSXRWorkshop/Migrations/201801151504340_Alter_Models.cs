namespace GSXRWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Models : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerAddresses", "ZipCode", c => c.String(maxLength: 6));
            AlterColumn("dbo.EmployeeAddresses", "ZipCode", c => c.String(maxLength: 6));
            AlterColumn("dbo.Repairs", "Notes", c => c.String(nullable: false));
            AlterColumn("dbo.GarageAddresses", "ZipCode", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GarageAddresses", "ZipCode", c => c.String());
            AlterColumn("dbo.Repairs", "Notes", c => c.String());
            AlterColumn("dbo.EmployeeAddresses", "ZipCode", c => c.String());
            AlterColumn("dbo.CustomerAddresses", "ZipCode", c => c.String());
        }
    }
}
