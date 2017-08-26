using System.Collections.Generic;
using Common;
using Common.Sensors;

namespace Stethoscope.Sensors
{
    public class DiskSpaceSensor : Sensor<DiskSensorReading>
    {
        public DiskSpaceSensor(SqlConnectionManager connectionManager) : base(connectionManager)
        {
        }

        public override IEnumerable<DiskSensorReading> MakeReading()
        {
            var procedureResult = ConnectionManager.ExecuteStoredProcWithReader("Sensors.ReadDiskSpace");
            var readings = DiskSensorReading.FromDataReader(procedureResult.DataReader);

            return readings;
        }
    }
}
