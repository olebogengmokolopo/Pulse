﻿using System;
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
        [Route("", Name = "GetDiskSummaries")]
        [HttpGet]
        [ResponseType(typeof(List<DiskSensorReading>))]
        public IEnumerable<DiskSensorReading> GetDiskSummaries([FromBody]int tenantId)
        {
            var diskSummaries = !AuthorisedForTenant(tenantId, "User")
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
        public IEnumerable<DiskSensorReading> GetDiskHistories([FromBody]int tenantId, int previousDays = 7)
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


