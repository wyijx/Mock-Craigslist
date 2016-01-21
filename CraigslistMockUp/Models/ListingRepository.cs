using CoderCamps.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CraigslistMockUp.Models
{
    public class ListingRepository : GenericRepository<Listing>
    {
        private ListingRepository(DbContext db) : base(db) { }

        public bool Update(Listing updates)
        {
            var dbItem = Get(updates.Id);
            if (dbItem != null)
            {
                dbItem.Description = updates.Description;
                dbItem.Category = updates.Category;
                dbItem.Owner = updates.Owner;
                dbItem.Picture = updates.Picture;
                dbItem.Title = updates.Title;

                try
                {
                    _db.SaveChanges();
                    return true;
                }
                catch { }
            }
            return false;
        }

        public IList<Listing> FindByCategory(string cat)
        {
            return (from l in Table
                    where l.Active && l.Category.Name == cat
                    select l).ToList();
        }
    }
}