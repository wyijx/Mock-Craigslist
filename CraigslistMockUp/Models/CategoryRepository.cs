using CoderCamps.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CraigslistMockUp.Models
{
    public class CategoryRepository : GenericRepository<Category>
    {
        private CategoryRepository(ApplicationDbContext db) : base(db) { }

        public bool Update(Category updates)
        {
            var dbItem = Get(updates.Id);
            if (dbItem != null)
            {
                dbItem.Listings = updates.Listings;
                dbItem.Name = updates.Name;
                try
                {
                    _db.SaveChanges();
                    return true;
                }
                catch { }
            }
            return false;
        }
    }
}