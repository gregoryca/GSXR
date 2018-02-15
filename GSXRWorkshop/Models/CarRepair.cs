using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSXRWorkshop.Models
{
    public class CarRepair
    {
        [Key]
        public int RepairId { get; set; }

        [DisplayName("Fault")]
        public string RepairName { get; set; }

        [StringLength(250, MinimumLength = 1)]
        [Required(ErrorMessage = "Note cannot be empty, or longer than 250 characters")]
        public string Notes { get; set; }

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}