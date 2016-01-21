using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CraigslistMockUp.Models {
    public class User : IActivatable, IDbEntity {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public IList<Listing> Listings { get; set; }

        public bool Active { get; set; } = true;
    }
}