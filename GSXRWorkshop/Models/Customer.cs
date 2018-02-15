using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GSXRWorkshop.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [StringLength(50)]
        [DisplayName("Customer name")]
        public string Name { get; set; }

        [DisplayName("Motorcycle")]
        public int MotorcycleId { get; set; }

        [ForeignKey("MotorcycleId")]
        public virtual MotorCycle Motorcycle { get; set; }
    }
}