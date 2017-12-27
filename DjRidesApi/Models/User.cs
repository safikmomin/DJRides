using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjRidesApi.Models
{
    public class User
    {
        public int UserID { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string AuthID { get; set; }

        public Address Address { get; set; }

        public ICollection<Car> Car { get; set; }
    }
}
