using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ThisIsCar.DAL;
using ThisIsCar.Models;

namespace ThisIsCar.Controllers
{
    public class ManufacturerController : ApiController
    {
        private CarContext db = new CarContext();

		// GET: api/Manufacturer
		public IQueryable<Manufacturer> GetManufacturers()
        {
            return db.Manufacturers;
        }

		// GET: api/Manufacturer/5
		[ResponseType(typeof(Manufacturer))]
        public IHttpActionResult GetManufacturer(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(manufacturer);
        }

		// PUT: api/Manufacturer/5
		[ResponseType(typeof(void))]
        public IHttpActionResult PutManufacturer(int id, Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manufacturer.Id)
            {
                return BadRequest();
            }

            db.Entry(manufacturer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerExists(id))
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

		// POST: api/Manufacturer
		[ResponseType(typeof(Manufacturer))]
        public IHttpActionResult PostManufacturer(Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = manufacturer.Id }, manufacturer);
        }

		// DELETE: api/Manufacturer/5
		[ResponseType(typeof(Manufacturer))]
        public IHttpActionResult DeleteManufacturer(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            db.Manufacturers.Remove(manufacturer);
            db.SaveChanges();

            return Ok(manufacturer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManufacturerExists(int id)
        {
            return db.Manufacturers.Count(e => e.Id == id) > 0;
        }
    }
}
