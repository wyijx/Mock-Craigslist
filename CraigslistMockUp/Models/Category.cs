using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CraigslistMockUp.Models {
    public class Category : IActivatable, IDbEntity {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Listing> Listings { get; set; }

        public bool Active { get; set; } = true;
    }
}