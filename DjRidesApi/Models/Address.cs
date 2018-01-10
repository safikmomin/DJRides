using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DjRidesApi.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        
        [Required]
        public string Street1 { get; set; }
        
        public string Street2 { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string State { get; set; }

        [Required]
        public int ZipCode { get; set; }

        public int Country { get; set; }

        public int UserProfileID { get; set; }
        


        public UserProfile User { get; set; }

    }
}
