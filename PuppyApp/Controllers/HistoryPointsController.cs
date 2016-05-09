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
using PuppyApp.DTOS;
using PuppyApp.Models;

namespace PuppyApp.Controllers
{
    public class HistoryPointsController : ApiController
    {
        private PuppyServiceContext db = new PuppyServiceContext();

        // GET: api/HistoryPoints
        public IQueryable<HistoryPoint> GetHistoryPoints()
        {
            return db.HistoryPoints;
        }

        [Route("api/HistoryPoints/Recent")]
        public IQueryable<HistoryGeoJsonDTO> GetRecentHistory()
        {
            var result = AutoMapperConfig.AppMapper.Map<HistoryPoint[], HistoryGeoJsonDTO[]>(db.HistoryPoints.ToArray());
            return result.AsQueryable();
        }

        // GET: api/HistoryPoints/5
        [ResponseType(typeof(HistoryPoint))]
        public async Task<IHttpActionResult> GetHistoryPoint(int id)
        {
            HistoryPoint historyPoint = await db.HistoryPoints.FindAsync(id);
            if (historyPoint == null)
            {
                return NotFound();
            }

            return Ok(historyPoint);
        }

        // PUT: api/HistoryPoints/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHistoryPoint(int id, HistoryPoint historyPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historyPoint.Id)
            {
                return BadRequest();
            }

            db.Entry(historyPoint).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryPointExists(id))
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

        // POST: api/HistoryPoints
        [ResponseType(typeof(HistoryPoint))]
        public async Task<IHttpActionResult> PostHistoryPoint(HistoryPointDTO historyPointDTO)
        {
            HistoryPoint historyPoint = AutoMapperConfig.AppMapper.Map<HistoryPointDTO, HistoryPoint>(historyPointDTO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HistoryPoints.Add(historyPoint);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = historyPoint.Id }, historyPoint);
        }

        // DELETE: api/HistoryPoints/5
        [ResponseType(typeof(HistoryPoint))]
        public async Task<IHttpActionResult> DeleteHistoryPoint(int id)
        {
            HistoryPoint historyPoint = await db.HistoryPoints.FindAsync(id);
            if (historyPoint == null)
            {
                return NotFound();
            }

            db.HistoryPoints.Remove(historyPoint);
            await db.SaveChangesAsync();

            return Ok(historyPoint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoryPointExists(int id)
        {
            return db.HistoryPoints.Count(e => e.Id == id) > 0;
        }
    }
}