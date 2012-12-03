using System.Collections.Generic;
using System.Web.Http;

namespace RestApiExample.Controllers
{
    public class ProspectsController : ApiController
    {
        // GET api/propspects/
        public IEnumerable<string> Get()
        {
            return new string[] { "Prospect1", "Prospect2" };
        }

        // GET api/prospects/5
        public string Get(int id)
        {
            return "Prospect" + id;
        }

        // POST api/values
        public IEnumerable<string> Post()
        {
            return new string[] { "value1", "value2" };
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        } 
    }
}