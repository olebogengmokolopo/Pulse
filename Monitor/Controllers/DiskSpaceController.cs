using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Monitor.Controllers
{
    [RoutePrefix("api/diskspace")]
    public class DiskSpaceController : ApiController
    {
        // GET api/values
        [Authorize]
        [Route("", Name = "GetDiskSummaries")]
        [HttpGet]
        [ResponseType(typeof(List<DiskSensorReading>))]
        public IEnumerable<DiskSensorReading> GetDiskSummaries()
        {
            var diskSummaries = new List<DiskSensorReading> { new DiskSensorReading(DateTime.Now, "C:/", "OS Drive", 1234, 456) };
            return diskSummaries;
        }

        [Authorize]
        [Route("history", Name = "GetDiskHistories")]
        [HttpGet]
        [ResponseType(typeof(List<DiskSensorReading>))]
        public IEnumerable<DiskSensorReading> GetDiskHistories(int previousDays = 7)
        {
            var diskHistories = new List<DiskSensorReading> { new DiskSensorReading(DateTime.Now, "C:/", "OS Drive", 1234, 456) };
            return diskHistories;
        }

        [Authorize]
        [Route("", Name = "CreateNewDiskReading")]
        [HttpPost]
        public IHttpActionResult GetDiskHistories([FromBody]DiskSensorReading diskSensorDto)
        {
            var diskHistories = new List<DiskSensorReading> { new DiskSensorReading(DateTime.Now, "C:/", "OS Drive", 1234, 456) };

            return Ok();
        }
    }
}


