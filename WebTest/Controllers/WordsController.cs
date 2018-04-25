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
using WebTest.Models;

namespace WebTest.Controllers
{
    public class WordsController : ApiController
    {
        private DictionaryGameEntities db = new DictionaryGameEntities();
        private DictionaryGameEntitiesNew new_db = new DictionaryGameEntitiesNew();

        int rand;

        // GET: api/Words
        public IQueryable<dictionary> GetWords()
        {
            rand = new Random().Next(db.Words.Count());
            //Word word = db.Words.ElementAt(rand.Next(db.Words.Count()));
            dictionary dictionary = new_db.dictionaries.OrderBy(r => Guid.NewGuid()).Skip(rand).Take(1).First();
            //return db.Words;
            List<dictionary> words = new List<dictionary>();
            words.Add(dictionary);
            return (words.AsQueryable());
        }

        // GET: api/Words/5
        [ResponseType(typeof(dictionary))]
        public async Task<IHttpActionResult> GetWord(int id)
        {
            //Word word = await db.Words.FindAsync(id);
            rand = new Random().Next(new_db.dictionaries.Count());
            dictionary word = new_db.dictionaries.OrderBy(r => Guid.NewGuid()).Skip(rand).Take(1).First();
            if (word == null)
            {
                return NotFound();
            }

            return Ok(word);
        }

        // PUT: api/Words/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWord(int id, Word word)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != word.WordID)
            {
                return BadRequest();
            }

            db.Entry(word).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordExists(id))
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

        // POST: api/Words
        [ResponseType(typeof(Word))]
        public async Task<IHttpActionResult> PostWord(Word word)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Words.Add(word);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = word.WordID }, word);
        }

        // DELETE: api/Words/5
        [ResponseType(typeof(Word))]
        public async Task<IHttpActionResult> DeleteWord(int id)
        {
            Word word = await db.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            db.Words.Remove(word);
            await db.SaveChangesAsync();

            return Ok(word);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WordExists(int id)
        {
            return db.Words.Count(e => e.WordID == id) > 0;
        }
    }
}