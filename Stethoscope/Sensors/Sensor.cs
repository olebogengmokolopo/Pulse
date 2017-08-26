using System.Collections.Generic;
using Common;
using Common.Sensors;

namespace Stethoscope.Sensors
{
    public abstract class Sensor<T> : ISensor<T> where T : ISensorReading
    {
        protected readonly SqlConnectionManager ConnectionManager;

        protected Sensor(SqlConnectionManager connectionManager)
        {
            ConnectionManager = connectionManager;
        }

        public abstract IEnumerable<T> MakeReading();
    }
}
