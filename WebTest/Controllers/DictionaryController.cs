using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebTest.Controllers
{
    public class DictionaryController : ApiController
    {
        // GET: api/Dictionary
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Dictionary/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Dictionary
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Dictionary/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Dictionary/5
        public void Delete(int id)
        {
        }
    }
}
