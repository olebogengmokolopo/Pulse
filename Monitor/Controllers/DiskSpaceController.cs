using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Monitor.Controllers
{
    [RoutePrefix("api/diskspace")]
    public class DiskSpaceController : ApiController
    {
        // GET api/values
        public IEnumerable<DiskSummary> Get()
        {
            var diskSummaries = new List<DiskSummary> { new DiskSummary("C:/", "OS Drive", 1234, 456) };
            return diskSummaries;
        }
    }
}
