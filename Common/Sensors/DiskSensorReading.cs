using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace Common.Sensors
{
    public class DiskSensorReading : ISensorReading
    {
        public int Id { get; set; } = 0;
        public int TenantId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Label { get; set; }
        public string Volume { get; set; }
        public float AvailableSpace { get; set; }
        public float TotalSpace { get; set; }
        public float UsedSpace { get; set; }

        public string SensorTarget = "/diskspace";
        public string GetSensorTarget()
        {
            return SensorTarget;
        }

        public DiskSensorReading()
        {
            
        }

        public DiskSensorReading(DateTime timestamp, string label, string volume, float totalSpace, float availableSpace)
        {
            TenantId = 1;
            Timestamp = timestamp;
            Label = label;
            Volume = volume;
            AvailableSpace = availableSpace;
            TotalSpace = totalSpace;
            CalculateUsedSpace();
        }

        public void CalculateUsedSpace()
        {
            UsedSpace = TotalSpace - AvailableSpace;
        }

        public static IEnumerable<DiskSensorReading> FromDataReader(DbDataReader dataReader)
        {
            var sensorReadings = new List<DiskSensorReading>();

            while (dataReader.Read())
            {
                var timestamp = (DateTime)dataReader["Timestamp"];
                var volume = dataReader["Volume"].ToString();
                var label = dataReader["Label"].ToString();
                var availableSpace = (float)(long)dataReader["AvailableSpace"];
                var totalSpace = (float)(long)dataReader["TotalSpace"];

                sensorReadings.Add(new DiskSensorReading(timestamp, label, volume, totalSpace, availableSpace));
            }

            dataReader.Close();

            return sensorReadings;
        }
    }
}