using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using GSXRWorkshop.Models;

namespace GSXRWorkshop.ViewModels
{
    public class GarageViewModel
    {
        public int MotorCycleId { get; set; }
        public int CarId { get; set; }
    }
}