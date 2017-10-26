using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;
using Common.Sensors;
using Monitor.Contexts;

namespace Monitor.Controllers
{
    [RoutePrefix("diskspace")]
    public class DiskSpaceController : BaseApiController
    {
        [Authorize]
        [Route("{tenantId}", Name = "GetDiskSummaries")]
        [HttpGet]
        [ResponseType(typeof(List<DiskSensorReading>))]
        public IEnumerable<DiskSensorReading> GetDiskSummaries(int tenantId)
        {
            var diskSummaries = !AuthorisedForTenant(tenantId, "User")
                ? null
                : new List<DiskSensorReading>();
            using (var context = new PulseWebContext())
            {
                diskSummaries = context.DiskSensorReadings
                    .Where(r => r.TenantId == tenantId)
                    .GroupBy(r => r.Volume)
                    .Select(g => g.OrderByDescending(r => r.Timestamp).FirstOrDefault())
                    
                    .ToList();
            }
            return diskSummaries;
        }

        [Authorize]
        [Route("{tenantId}/history", Name = "GetDiskHistories")]
        [HttpGet]
        [ResponseType(typeof(List<DiskSensorReading>))]
        public IEnumerable<DiskSensorReading> GetDiskHistories(int tenantId, int previousDays = 7)
        {
            var diskHistories = !AuthorisedForTenant(tenantId, "User") 
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

        [Authorize(Roles="Tenant")]
        [Route("", Name = "CreateNewDiskReading")]
        [HttpPost]
        public IHttpActionResult CreateNewDiskReading([FromBody]DiskSensorReading diskSensorDto)
        {
            Debug.WriteLine(CurrentUser.IsTenant.ToString());
            Debug.WriteLine(AuthorisedAsTenant().ToString());
            Debug.WriteLine(CurrentUser.TenancyUserRoles.Count.ToString());

            if (!CurrentUser.IsTenant) return BadRequest();
            if (!AuthorisedAsTenant()) return Unauthorized();

            diskSensorDto.TenantId = CurrentUser.TenancyUserRoles.Single().TenancyId;
            diskSensorDto.CalculateUsedSpace();
            using (var context = new PulseWebContext())
            {
                context.DiskSensorReadings.Add(diskSensorDto);
                context.SaveChanges();
            }

            return Ok();
        }
    }
}


