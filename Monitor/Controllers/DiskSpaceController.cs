using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Monitor.Controllers
{
    [Authorize]
    public class DiskSpaceController : ApiController
    {
        // GET api/values
        public IEnumerable<Disk> Get()
        {
            return new List<Disk> { new Disk("C:/", "OS Drive", 1234, 456) };
        }
    }
}
