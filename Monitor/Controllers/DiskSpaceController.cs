using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Common.Sensors;

namespace Monitor.Controllers
{
    [RoutePrefix("api/{tenantId}/diskspace")]
    public class DiskSpaceController : BaseApiController
    {
        [Authorize]
        [Route("", Name = "GetDiskSummaries")]
        [HttpGet]
        [ResponseType(typeof(List<DiskSensorReading>))]
        public IEnumerable<DiskSensorReading> GetDiskSummaries(int tenantId)
        {
            var diskSummaries = !AuthorisedForTenant(tenantId, "Tenant")
                ? null
                : new List<DiskSensorReading>();
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
            var diskHistories = !AuthorisedForTenant(tenantId, "Tenant") 
                    ? null
                    : new List<DiskSensorReading>();
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
        public IHttpActionResult GetDiskHistories(int tenantId, [FromBody]DiskSensorReading diskSensorDto)
        {
            if (!AuthorisedForTenant(tenantId, "Tenant"))
            {
                return BadRequest();
            }

            //using (var context = new PulseContext())
            //{
            //    context.DiskSensorReadings.Add(diskSensorDto);
            //    context.SaveChanges();
            //}
            return Ok();
        }
    }
}


