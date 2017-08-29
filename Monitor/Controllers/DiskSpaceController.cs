using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Common.Sensors;

namespace Monitor.Controllers
{
    [RoutePrefix("api/{tenantId}/diskspace")]
    public class DiskSpaceController : ApiController
    {
        // GET api/values
        [Authorize]
        [Route("", Name = "GetDiskSummaries")]
        [HttpGet]
        [ResponseType(typeof(List<DiskSensorReading>))]
        public IEnumerable<DiskSensorReading> GetDiskSummaries(int tenantId)
        {
            List<DiskSensorReading> diskSummaries = new List<DiskSensorReading>();
            //using (var context = new PulseContext())
            //{
            //    diskSummaries = context.DiskSensorReadings
            //        .Select(r => r)
            //        .GroupBy(r => r.Volume)
            //        .Select(g => g.OrderByDescending(r => r.Timestamp).First())
            //        .Select(r => new DiskSensorReading(r.Timestamp, r.Label, r.Volume, r.TotalSpace, r.AvailableSpace))
            //        .ToList();
            //}
            return diskSummaries;
        }

        [Authorize]
        [Route("history", Name = "GetDiskHistories")]
        [HttpGet]
        [ResponseType(typeof(List<DiskSensorReading>))]
        public IEnumerable<DiskSensorReading> GetDiskHistories(int tenantId, int previousDays = 7)
        {
            List<DiskSensorReading> diskHistories = new List<DiskSensorReading>();
            //using (var context = new PulseContext())
            //{
            //    diskHistories = context.DiskSensorReadings
            //                        .Select(reading => reading)
            //                        .Where(reading => reading.Timestamp.AddDays(previousDays) > DateTime.Now)
            //                        .ToList();
            //}
            return diskHistories;
        }

        [Authorize]
        [Route("", Name = "CreateNewDiskReading")]
        [HttpPost]
        public IHttpActionResult GetDiskHistories(int tenantI, [FromBody]DiskSensorReading diskSensorDto)
        {
            //using (var context = new PulseContext())
            //{
            //    context.DiskSensorReadings.Add(diskSensorDto);
            //    context.SaveChanges();
            //}
            return Ok();
        }
    }
}


