using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APITecsup.Context;
using APITecsup.Models;

namespace APITecsup.Controllers
{
    public class MusicasController : ApiController
    {
        private ExampleContext db = new ExampleContext();

        // GET: api/Musicas
        public IQueryable<Musica> GetMusicas()
        {
            return db.Musicas;
        }

        // GET: api/Musicas/5
        [ResponseType(typeof(Musica))]
        public IHttpActionResult GetMusica(int id)
        {
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return NotFound();
            }

            return Ok(musica);
        }

        // PUT: api/Musicas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMusica(int id, Musica musica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != musica.MusicID)
            {
                return BadRequest();
            }

            db.Entry(musica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicaExists(id))
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

        // POST: api/Musicas
        [ResponseType(typeof(Musica))]
        public IHttpActionResult PostMusica(Musica musica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Musicas.Add(musica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = musica.MusicID }, musica);
        }

        // DELETE: api/Musicas/5
        [ResponseType(typeof(Musica))]
        public IHttpActionResult DeleteMusica(int id)
        {
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return NotFound();
            }

            db.Musicas.Remove(musica);
            db.SaveChanges();

            return Ok(musica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MusicaExists(int id)
        {
            return db.Musicas.Count(e => e.MusicID == id) > 0;
        }
    }
}