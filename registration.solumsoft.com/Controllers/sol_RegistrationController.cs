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
using WebApplication2013.Models;

namespace WebApplication2013.Controllers
{
    public class sol_RegistrationController : ApiController
    {
        private sol_RegistrationContext db = new sol_RegistrationContext();

        // GET api/sol_Registration
        public IQueryable<sol_Registration> Getsol_Registration()
        {
            return db.sol_Registration;
        }

        // GET api/sol_Registration/5
        [ResponseType(typeof(sol_Registration))]
        public async Task<IHttpActionResult> Getsol_Registration(int id)
        {
            sol_Registration sol_registration = await db.sol_Registration.FindAsync(id);
            if (sol_registration == null)
            {
                return NotFound();
            }

            return Ok(sol_registration);
        }

        // PUT api/sol_Registration/5
        public async Task<IHttpActionResult> Putsol_Registration(int id, sol_Registration sol_registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sol_registration.sol_RegistrationId)
            {
                return BadRequest();
            }

            db.Entry(sol_registration).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sol_RegistrationExists(id))
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

        // POST api/sol_Registration
        [ResponseType(typeof(sol_Registration))]
        public async Task<IHttpActionResult> Postsol_Registration(sol_Registration sol_registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sol_Registration.Add(sol_registration);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sol_registration.sol_RegistrationId }, sol_registration);
        }

        // DELETE api/sol_Registration/5
        [ResponseType(typeof(sol_Registration))]
        public async Task<IHttpActionResult> Deletesol_Registration(int id)
        {
            sol_Registration sol_registration = await db.sol_Registration.FindAsync(id);
            if (sol_registration == null)
            {
                return NotFound();
            }

            db.sol_Registration.Remove(sol_registration);
            await db.SaveChangesAsync();

            return Ok(sol_registration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sol_RegistrationExists(int id)
        {
            return db.sol_Registration.Count(e => e.sol_RegistrationId == id) > 0;
        }
    }
}