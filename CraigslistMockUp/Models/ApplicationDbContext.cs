using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CraigslistMockUp.Models {
    public class ApplicationDbContext : DbContext{
        public IDbSet<User> Users { get; set; }
        public IDbSet<Listing> Listings { get; set; }
        public IDbSet<Category> Categories { get; set; }
    }
}