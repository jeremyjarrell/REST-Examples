using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;

namespace RestApiExample.Controllers
{
    public class ProspectsController : ApiController
    {
        private readonly ProspectsRepository _repository = new ProspectsRepository();

        // GET api/prospects/
        // Returns 200
        public IEnumerable<Prospect> Get()
        {
            return _repository.FindAll(p => true);
        }

        // GET api/prospects/5
        // Returns 200
        public Prospect Get(int id)
        {
            return _repository.FindAll(p => p.Id == id).First();
        }

        // POST api/prospects
        // // Returns 204 by default, overridden to return 201
        public HttpResponseMessage Post(Prospect prospect)
        {
            var addedProspect = _repository.Add(prospect);

            // WebAPI will return 204 by default, however, the HTTP spec states that successful
            // POSTs should return 201 with a link to the newly created resource.
            var response = Request.CreateResponse(HttpStatusCode.Created, prospect);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = addedProspect.Id}));
            return response;
        }
        

        // To enable PUT and DELETE verbs on IIS you'll need to disable WebDAV at the IIS instance level.
        // See this SO question for more information: http://stackoverflow.com/questions/10906411/asp-net-web-api-put-delete-verbs-not-allowed-iis-8

        // PUT api/prospects/5
        // Returns 204
        public void Put(int id, [FromBody] string value)
        {
            var matchedProspect = _repository.FindAll(p => p.Id == id).First();
            _repository.Delete(matchedProspect);

            matchedProspect.Name = value;
            _repository.Add(matchedProspect);
        }

        // DELETE api/prospects/5
        // Returns 204
        public void Delete(int id)
        {
            var prospectToBeDeleted = _repository.FindAll(p => p.Id == id).First();
            _repository.Delete(prospectToBeDeleted);
        }
    }
}