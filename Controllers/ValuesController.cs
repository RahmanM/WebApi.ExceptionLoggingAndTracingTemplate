using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.ExceptionAndLogging.ExceptionTypes;

namespace WebApi.ExceptionAndLogging.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            if (id > 1000)
            {
                throw new InvalidOperationException("Id should be smaller than 1000");
            }

            return "value";
        }

        [Route("api/Values/GetByName/{name:alpha}")]
        public string GetByName(string name)
        {
            if (name == "rahman")
            {
                throw new BusinessException("Rahman is not allowed!");
            }

            return "value 1";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
