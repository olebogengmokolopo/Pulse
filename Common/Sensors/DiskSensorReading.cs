using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Common.Sensors
{
    public class DiskSensorReading : ISensorReading
    {
        public int TenantKey { get; }
        public DateTime Timestamp { get; }
        public string Label { get; }
        public string Volume { get; }
        public float AvailableSpace { get; }
        public float TotalSpace { get; }
        public float UsedSpace { get; }

        public string SensorTarget;
        public string GetSensorTarget()
        {
            return SensorTarget;
        }

        public DiskSensorReading(DateTime timestamp, string label, string volume, float totalSpace, float availableSpace)
        {
            TenantKey = 1;
            Timestamp = timestamp;
            Label = label;
            Volume = volume;
            AvailableSpace = availableSpace;
            TotalSpace = totalSpace;
            UsedSpace = totalSpace - availableSpace;
        }
        public static IEnumerable<DiskSensorReading> FromDataReader(DbDataReader dataReader)
        {
            var sensorReadings = new List<DiskSensorReading>();

            while (dataReader.Read())
            {
                var timestamp = (DateTime)dataReader["Timestamp"];
                var label = dataReader["Label"].ToString();
                var volume = dataReader["Volume"].ToString();
                var availableSpace = (float)dataReader["AvailableSpace"];
                var totalSpace = (float)dataReader["TotalSpace"];

                sensorReadings.Add(new DiskSensorReading(timestamp, label, volume, totalSpace, availableSpace));
            }

            return sensorReadings;
        }
    }
}