using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DjRidesApi.Models
{
    public class RideAddress
    {
        public int RideAddressID { get; set; }

        [Required]
        public int ToFrom { get; set; }

        [Required]
        public string Street1 { get; set; }

        public string Street2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        
        public int ZipCode { get; set; }

        public int Country { get; set; }
        
        public Ride Ride { get; set; }
    }
}
