using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DjRidesApi.Models
{
    public class Car
    {
        public int CarID { get; set; }

        public int UserID { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Color { get; set; }

        public string Year { get; set; }

        public string LicenseNumber { get; set; }
        
        public User User { get; set; }

    }
}
