using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSXRWorkshop.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [DisplayName("Street")]
        public string StreetName { get; set; }
        [StringLength(6)]
        [Display(Name ="Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name ="House number")]
        public string Housenumber { get; set; }
        public string City { get; set; }
    }
}