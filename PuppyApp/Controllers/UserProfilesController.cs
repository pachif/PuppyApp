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
using AutoMapper;
using PuppyApp.DTOS;
using PuppyApp.Models;

namespace PuppyApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UserProfilesController : ApiController
    {
        private PuppyServiceContext db = new PuppyServiceContext();

        // GET: api/UserProfiles
        /// <summary>
        /// Return the list of user profiles
        /// </summary>
        /// <returns>a list of UserProfileDTO objects</returns>
        [ResponseType(typeof(IQueryable<UserProfileDTO>))]
        public IQueryable<UserProfileDTO> GetUserProfiles()
        {
            var result = AutoMapperConfig.AppMapper.Map<UserProfile[], UserProfileDTO[]>(db.UserProfiles.ToArray());
            return result.AsQueryable();
        }

        /// <summary>
        /// Returns an array of Pets objects within this owner
        /// </summary>
        /// <param name="id">the user profile id</param>
        /// <returns>array of pets objects</returns>
        [ResponseType(typeof(IQueryable<PetDTO>))]
        [Route("api/UserProfiles/{id}/Pets")]
        public async Task<IHttpActionResult> GetUserProfilePets(int id) {
            var profile = await db.UserProfiles.Include(x => x.Mascots).SingleOrDefaultAsync(x => x.Id == id);
            if (profile == null) {
                return NotFound();
            }

            var result = AutoMapperConfig.AppMapper.Map<Pet[], PetDTO[]>(profile.Mascots.ToArray());
            return Ok(result.AsQueryable());
        }

        // GET: api/UserProfiles/5
        [ResponseType(typeof(UserProfile))]
        public async Task<IHttpActionResult> GetUserProfile(int id)
        {
            UserProfile userProfile = await db.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        // PUT: api/UserProfiles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserProfile(int id, UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProfile.Id)
            {
                return BadRequest();
            }

            db.Entry(userProfile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileExists(id))
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

        // POST: api/UserProfiles
        [ResponseType(typeof(UserProfile))]
        public async Task<IHttpActionResult> PostUserProfile(UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserProfiles.Add(userProfile);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userProfile.Id }, userProfile);
        }

        // DELETE: api/UserProfiles/5
        [ResponseType(typeof(UserProfile))]
        public async Task<IHttpActionResult> DeleteUserProfile(int id)
        {
            UserProfile userProfile = await db.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            db.UserProfiles.Remove(userProfile);
            await db.SaveChangesAsync();

            return Ok(userProfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserProfileExists(int id)
        {
            return db.UserProfiles.Count(e => e.Id == id) > 0;
        }
    }
}