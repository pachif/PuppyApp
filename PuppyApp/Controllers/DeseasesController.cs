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
using PuppyApp.Models;

namespace PuppyApp.Controllers
{
    public class DeseasesController : ApiController
    {
        private PuppyServiceContext db = new PuppyServiceContext();

        // GET: api/Deseases
        public IQueryable<Desease> GetDeseases()
        {
            return db.Deseases;
        }

        // GET: api/Deseases/5
        [ResponseType(typeof(Desease))]
        public async Task<IHttpActionResult> GetDesease(int id)
        {
            Desease desease = await db.Deseases.FindAsync(id);
            if (desease == null)
            {
                return NotFound();
            }

            return Ok(desease);
        }

        // PUT: api/Deseases/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDesease(int id, Desease desease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != desease.Id)
            {
                return BadRequest();
            }

            db.Entry(desease).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeseaseExists(id))
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

        // POST: api/Deseases
        [ResponseType(typeof(Desease))]
        public async Task<IHttpActionResult> PostDesease(Desease desease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deseases.Add(desease);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = desease.Id }, desease);
        }

        // DELETE: api/Deseases/5
        [ResponseType(typeof(Desease))]
        public async Task<IHttpActionResult> DeleteDesease(int id)
        {
            Desease desease = await db.Deseases.FindAsync(id);
            if (desease == null)
            {
                return NotFound();
            }

            db.Deseases.Remove(desease);
            await db.SaveChangesAsync();

            return Ok(desease);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeseaseExists(int id)
        {
            return db.Deseases.Count(e => e.Id == id) > 0;
        }
    }
}