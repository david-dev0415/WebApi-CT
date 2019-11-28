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
    public class PartnersController : ApiController
    {
        private DB_A4DEDC_CTReportEntities db = new DB_A4DEDC_CTReportEntities();

        // GET: api/Partners
        public IQueryable<Partner> GetPartner()
        {
            return db.Partner;
        }

        // GET: api/Partners/5
        [ResponseType(typeof(Partner))]
        public async Task<IHttpActionResult> GetPartner(int id)
        {
            Partner partner = await db.Partner.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }

            return Ok(partner);
        }

        // PUT: api/Partners/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPartner(int id, Partner partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partner.InPartner)
            {
                return BadRequest();
            }

            db.Entry(partner).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExists(id))
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

        // POST: api/Partners
        [ResponseType(typeof(Partner))]
        public async Task<IHttpActionResult> PostPartner(Partner partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Partner.Add(partner);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PartnerExists(partner.InPartner))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = partner.InPartner }, partner);
        }

        // DELETE: api/Partners/5
        [ResponseType(typeof(Partner))]
        public async Task<IHttpActionResult> DeletePartner(int id)
        {
            Partner partner = await db.Partner.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }

            db.Partner.Remove(partner);
            await db.SaveChangesAsync();

            return Ok(partner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartnerExists(int id)
        {
            return db.Partner.Count(e => e.InPartner == id) > 0;
        }
    }
}