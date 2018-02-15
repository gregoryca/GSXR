using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GSXRWorkshop.Models
{
    public class Dragtimes
    {
        [Key]
        public int DragtimeId { get; set; }
        public string City { get; set; }
        public TimeSpan DragTime { get; set; }

        public int MotorCycleId { get; set; }

        [Required]
        [ForeignKey("MotorCycleId")]
        public virtual MotorCycle MotorCycle { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}