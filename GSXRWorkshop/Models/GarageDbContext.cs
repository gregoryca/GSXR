using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GSXRWorkshop.Models
{
    public class GarageDbContext : ApplicationDbContext
    {
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<MotorCycle> Motorcycles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Car> Cars { get; set; }

        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<GarageAddress> GarageAddress { get; set; }

        public System.Data.Entity.DbSet<GSXRWorkshop.Models.CarRepair> CarRepairs { get; set; }


        //public System.Data.Entity.DbSet<GSXRWorkshop.Models.Dragtimes> Dragtimes { get; set; }
    }
}