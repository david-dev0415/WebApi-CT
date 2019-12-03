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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ConsolidatesController : ApiController
    {
        private DB_A4DEDC_CTReportEntities db = new DB_A4DEDC_CTReportEntities();

        // GET: api/Consolidates
        public IQueryable<Consolidate> GetConsolidate()
        {
            return db.Consolidate;
        }

        // GET: api/Consolidates/5
        [ResponseType(typeof(Consolidate))]
        public async Task<IHttpActionResult> GetConsolidate(string id)
        {
            Consolidate consolidate = await db.Consolidate.FindAsync(id);
            if (consolidate == null)
            {
                return NotFound();
            }
            
            return Ok(consolidate);
        }

        // PUT: api/Consolidates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConsolidate(string id, Consolidate consolidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consolidate.IdConsolidate)
            {
                return BadRequest();
            }

            db.Entry(consolidate.IdConsolidate).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsolidateExists(id))
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

        // POST: api/Consolidates
        [ResponseType(typeof(Consolidate))]
        public async Task<IHttpActionResult> PostConsolidate(Consolidate consolidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consolidate.Add(consolidate);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConsolidateExists(consolidate.IdConsolidate))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = consolidate.IdConsolidate }, consolidate);
        }

        // DELETE: api/Consolidates/5
        [ResponseType(typeof(Consolidate))]
        public async Task<IHttpActionResult> DeleteConsolidate(string id)
        {
            Consolidate consolidate = await db.Consolidate.FindAsync(id);
            if (consolidate == null)
            {
                return NotFound();
            }

            db.Consolidate.Remove(consolidate);
            await db.SaveChangesAsync();

            return Ok(consolidate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsolidateExists(string id)
        {
            return db.Consolidate.Count(e => e.IdConsolidate == id) > 0;
        }
    }
}