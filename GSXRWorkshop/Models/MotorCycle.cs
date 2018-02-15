using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GSXRWorkshop.Models
{
    public class MotorCycle
    {
        [Key]
        [DisplayName("Motorcycle")]
        public int MotorCycleId { get; set; }
        [DisplayName("Motorcycle name")]
        public string MotorCycleName { get; set; }
        public string Manufacturer { get; set; }
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }
        public string Model { get; set; }
        [DisplayName("Displacement ( CC )")]
        public string Displacement { get; set; }
        [DisplayName("Wheelbase ( Centimeters )")]
        public string Wheelbase { get; set; }
    }
}