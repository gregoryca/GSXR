using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GSXRWorkshop.Models
{
    public class Car
    {
        [Key]
        [DisplayName("Car")]
        public int CarId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }
        [DisplayName("Displacement ( CC )")]
        public string Displacement { get; set; }
        [DisplayName("Wheelbase ( Centimeters )")]
        public string Wheelbase { get; set; }
    }
}