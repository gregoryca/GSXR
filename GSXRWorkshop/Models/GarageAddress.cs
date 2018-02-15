using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Owin.BuilderProperties;

namespace GSXRWorkshop.Models
{
    public class GarageAddress : Address
    {
        public int GarageId { get; set; }

        [ForeignKey("GarageId")]
        public virtual Garage Garage { get; set; }
    }
}