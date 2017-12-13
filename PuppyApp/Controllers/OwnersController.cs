using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PuppyApp;
using PuppyApp.DTOS;
using PuppyApp.Models;

namespace PuppyApp.Controllers
{
    public class OwnersController : ApiController
    {
        private PuppyServiceContext db = new PuppyServiceContext();

        // GET: api/Owners
        public IQueryable<Owner> GetOwners()
        {
            return db.Owners;
        }

        // GET: api/Owners/25564654
        public IQueryable<Owner> GetOwners(string card) {
            return db.Owners.Where(x => x.IDCard.Contains(card));
        }

        // GET: api/Owners/Options
        [Route("api/Owners/Options")]
        public IQueryable<ComboOptionsDTO> GetOwnersOptions() {
            var result = AutoMapperConfig.AppMapper.Map<Owner[], ComboOptionsDTO[]>(db.Owners.ToArray());
            return result.AsQueryable();
        }

        /// <summary>
        /// Returns an array of Pets objects within this owner
        /// </summary>
        /// <param name="id">the user profile id</param>
        /// <returns>array of pets objects</returns>
        [ResponseType(typeof(IQueryable<PetDTO>))]
        [Route("api/Owners/{id}/Pets")]
        public async Task<IHttpActionResult> GetPets(int id) {
            var profile = await db.Owners.Include(x => x.Mascots).SingleOrDefaultAsync(x => x.Id == id);
            if (profile == null) {
                return NotFound();
            }

            var result = AutoMapperConfig.AppMapper.Map<Pet[], PetDTO[]>(profile.Mascots.ToArray());
            return Ok(result.AsQueryable());
        }

        // GET: api/Owners/5
        [ResponseType(typeof(Owner))]
        public IHttpActionResult GetOwner(int id)
        {
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        // PUT: api/Owners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOwner(int id, Owner owner)
        {
            // this only to create new

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != owner.Id)
            {
                return BadRequest();
            }

            db.Entry(owner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Owners
        [ResponseType(typeof(Owner))]
        public IHttpActionResult PostOwner(Owner owner)
        {
            // POST is going to be reserved to update
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // if does not exists return 404
            if (!OwnerExists(owner.Id))
            {
                return NotFound();
            }

            var original = db.Owners.SingleOrDefault(o => o.Id == owner.Id);
            foreach (var mascot in owner.Mascots)
            {
                var pet =
                    original.Mascots.SingleOrDefault(
                        p => String.Equals(p.Name, mascot.Name, StringComparison.InvariantCultureIgnoreCase));
                if (pet!=null)
                {
                    original.Mascots.Remove(pet);
                    original.Mascots.Add(pet);
                }
            }

            db.Owners.Add(owner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = owner.Id }, owner);
        }

        // DELETE: api/Owners/5
        [ResponseType(typeof(Owner))]
        public IHttpActionResult DeleteOwner(int id)
        {
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return NotFound();
            }

            db.Owners.Remove(owner);
            db.SaveChanges();

            return Ok(owner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OwnerExists(int id)
        {
            return db.Owners.Count(e => e.Id == id) > 0;
        }
    }
}