using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSXRWorkshop.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Specialty { get; set; }
        [DisplayName("Phone number")]
        public int PhoneNumber { get; set; }

        public virtual List<Repair> Repairs { get; set; }
    }
}