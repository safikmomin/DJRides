using DjRidesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjRidesApi.Data
{
    public class DjRidesContext : DbContext
    {
        public DjRidesContext(DbContextOptions<DjRidesContext> options) : base(options)
        {
        }
        

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RideAddress> RideAddressess { get; set; }
        public DbSet<Ride> Rides { get; set; }
    }
}
