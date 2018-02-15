namespace GSXRWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Models1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarRepairs", "Notes", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Employees", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Repairs", "Notes", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Customers", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
            AlterColumn("dbo.Repairs", "Notes", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.CarRepairs", "Notes", c => c.String(nullable: false));
        }
    }
}
