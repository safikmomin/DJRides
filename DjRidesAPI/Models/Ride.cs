using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjRidesApi.Models
{
    public class Ride
    {
        public int RideID { get; set; }
        
        public int Availablity { get; set; }

        public int CarID { get; set; }

        public DateTime DateTime { get; set; }

        public UserProfile User { get; set; }

        public Car Car { get; set; }

        public int? Test { get; set; }

        public ICollection<RideAddress> Address { get; set; }
    }
}
