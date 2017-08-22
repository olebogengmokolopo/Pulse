using System;
using System.Collections.Generic;
using Monitor.Models;

namespace Stethoscope.Sensors
{
    class DiskSpaceSensor : ISensor<DiskSensorReading>
    {
        public IEnumerable<DiskSensorReading> MakeReading()
        {
            throw new NotImplementedException();
        }
    }
}
