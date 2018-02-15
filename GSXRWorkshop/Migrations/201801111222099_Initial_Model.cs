namespace GSXRWorkshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAddresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        StreetName = c.String(),
                        ZipCode = c.String(),
                        Housenumber = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MotorcycleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Motorcycles", t => t.MotorcycleId, cascadeDelete: true)
                .Index(t => t.MotorcycleId);
            
            CreateTable(
                "dbo.Motorcycles",
                c => new
                    {
                        MotorCycleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        Displacement = c.Single(nullable: false),
                        Wheelbase = c.Int(nullable: false),
                        Fault = c.String(),
                    })
                .PrimaryKey(t => t.MotorCycleId);
            
            CreateTable(
                "dbo.EmployeeAddresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        StreetName = c.String(),
                        ZipCode = c.String(),
                        Housenumber = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Specialty = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Repairs",
                c => new
                    {
                        RepairId = c.Int(nullable: false, identity: true),
                        RepairName = c.String(),
                        Notes = c.String(),
                        MotorCycleId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RepairId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Motorcycles", t => t.MotorCycleId, cascadeDelete: true)
                .Index(t => t.MotorCycleId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.GarageAddresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        GarageId = c.Int(nullable: false),
                        StreetName = c.String(),
                        ZipCode = c.String(),
                        Housenumber = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Garages", t => t.GarageId, cascadeDelete: true)
                .Index(t => t.GarageId);
            
            CreateTable(
                "dbo.Garages",
                c => new
                    {
                        GarageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CustomerId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GarageId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.GarageAddresses", "GarageId", "dbo.Garages");
            DropForeignKey("dbo.Garages", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Garages", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.EmployeeAddresses", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Repairs", "MotorCycleId", "dbo.Motorcycles");
            DropForeignKey("dbo.Repairs", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CustomerAddresses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "MotorcycleId", "dbo.Motorcycles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Garages", new[] { "EmployeeId" });
            DropIndex("dbo.Garages", new[] { "CustomerId" });
            DropIndex("dbo.GarageAddresses", new[] { "GarageId" });
            DropIndex("dbo.Repairs", new[] { "EmployeeId" });
            DropIndex("dbo.Repairs", new[] { "MotorCycleId" });
            DropIndex("dbo.EmployeeAddresses", new[] { "EmployeeId" });
            DropIndex("dbo.Customers", new[] { "MotorcycleId" });
            DropIndex("dbo.CustomerAddresses", new[] { "CustomerId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Garages");
            DropTable("dbo.GarageAddresses");
            DropTable("dbo.Repairs");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeAddresses");
            DropTable("dbo.Motorcycles");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerAddresses");
        }
    }
}
