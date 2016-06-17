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
    public class ModelController : ApiController
    {
        private CarContext db = new CarContext();

        // GET: api/Model
        public IQueryable<Model> GetModels()
        {
            return db.Models;
        }

        // GET: api/Model/5
        [ResponseType(typeof(Model))]
        public IHttpActionResult GetModel(int id)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Model/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModel(int id, Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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

        // POST: api/Model
        [ResponseType(typeof(Model))]
        public IHttpActionResult PostModel(Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Models.Add(model);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        // DELETE: api/Model/5
        [ResponseType(typeof(Model))]
        public IHttpActionResult DeleteModel(int id)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Models.Remove(model);
            db.SaveChanges();

            return Ok(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelExists(int id)
        {
            return db.Models.Count(e => e.Id == id) > 0;
        }
    }
}
