using CraigslistMockUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CraigslistMockUp.Controllers
{
    public class ListingsController : ApiController
    {
        private ListingRepository _repo;

        public ListingsController(ListingRepository repo)
        {
            _repo = repo;
        }

        public IList<Listing> Get()
        {
            return _repo.List();
        }

        public Listing Get(int id)
        {
            return _repo.Get(id);
        }

        // Create
        public IHttpActionResult Post(Listing newListing)
        {

            if (ModelState.IsValid)
            {
                try {
                    _repo.Add(newListing);
                    _repo.SaveChanges();
                    return Created("/api/listings/" + newListing.Id, newListing);
                }
                catch
                {
                    return InternalServerError();
                }
            }
            return BadRequest(ModelState);
        }

        // Update
        public IHttpActionResult Post(int id, Listing updates)
        {
            updates.Id = id;
            if (ModelState.IsValid)
            {
                if (_repo.Update(updates))
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var dbItem = _repo.Get(id);
                if (dbItem != null)
                {
                    _repo.Delete(id);
                    _repo.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            catch
            {
                   return InternalServerError();
            }
        }
    }
}
