using System;
using System.Configuration;
using Common;
using Common.Sensors;
using Stethoscope.Sensors;

namespace Stethoscope
{
    public static class Program
    {
        private static PulseReporter _reporter;
        private static SensorPoller<DiskSensorReading> _diskSpacePoller;
        private static DiskSpaceSensor _sensor;
        private static SqlConnectionManager _connectionManager;

        public static void Main()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SensorTargetConnection"].ConnectionString;
            var reporterTargetBaseUri = ConfigurationManager.AppSettings["ReporterTargetBaseUri"];
            var tenantName = ConfigurationManager.AppSettings["TenantName"];
            var delayInSeconds = int.Parse(ConfigurationManager.AppSettings["PollerDelayInSeconds"]);

            Console.WriteLine("Launched!");

            _connectionManager = new SqlConnectionManager(connectionString);

            _reporter = new PulseReporter(reporterTargetBaseUri, tenantName);
            _sensor = new DiskSpaceSensor(_connectionManager);
            _diskSpacePoller = new SensorPoller<DiskSensorReading>(_sensor, _reporter, delayInSeconds);

            _diskSpacePoller.Start();
        }
    }
}
