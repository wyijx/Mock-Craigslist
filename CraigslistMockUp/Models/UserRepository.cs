using CoderCamps.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CraigslistMockUp.Models
{
    public class UserRepository : GenericRepository<User>
    {
        private UserRepository(ApplicationDbContext db) : base(db) { }

        public bool Update(User updates)
        {
            var dbItem = Get(updates.Id);
            if(dbItem != null)
            {
                dbItem.Email = updates.Email;
                dbItem.Listings = updates.Listings;

                try
                {
                    _db.SaveChanges();
                    return true;
                }
                catch
                { }
            }
            return false;
        }
    } 
}