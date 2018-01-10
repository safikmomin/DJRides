using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjRidesApi.Models
{
    public class UserProfile
    {
        public int UserProfileID { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string AuthID { get; set; }

        public Address Address { get; set; }

        public ICollection<Ride> Ride { get; set; }

        public ICollection<Car> Car { get; set; }
    }
}
