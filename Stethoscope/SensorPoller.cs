using System;
using Stethoscope.Sensors;
using System.Data.SqlClient;
using System.Threading;
using Monitor.Models;
using NLog;

namespace Stethoscope
{
    public class SensorPoller<T> where T : ISensorReading
    {
        private readonly ISensor<T> _sensor;
        private readonly IReporter _reporter;

        private bool _isPolling;
        private readonly int _delayInSeconds;

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public SensorPoller(ISensor<T> sensor, IReporter reporter, int delayInSeconds)
        {
            _sensor = sensor;
            _isPolling = false;
            _delayInSeconds = delayInSeconds;
            _reporter = reporter;
        }

        public void Start()
        {
            _isPolling = true;
            while (_isPolling)
            {
                try
                {
                    Poll();
                    Thread.Sleep(_delayInSeconds);
                }
                catch (Exception e)
                {
                    Logger.Error("Sensor Exception occurred for: " + _sensor.GetType());
                    Logger.Error(e);
                    Stop();
                }
            }
        }

        public void Stop()
        {
            _isPolling = false;
        }

        public void Poll()
        { 
            var readings = _sensor.MakeReading();
            foreach (var reading in readings)
            {
                _reporter.Report(reading);
            }
            Logger.Info("Sensor reading reported for: " + _sensor.GetType());
        }
    }
}
