using System.Collections.Generic;
using System.Web.Http;

namespace GetCompliance.Services.API.Controllers
{
    public class EmailsController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }
    }
}
