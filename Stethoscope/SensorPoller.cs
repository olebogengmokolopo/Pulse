using System;
using Stethoscope.Sensors;
using System.Threading;
using Common.Sensors;
using NLog;

namespace Stethoscope
{
    public class SensorPoller<T> where T : ISensorReading
    {
        private readonly ISensor<T> _sensor;
        private readonly IReporter _reporter;

        private bool _isPolling;
        private readonly int _delayInSeconds;

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
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
                    Thread.Sleep(_delayInSeconds * 1000);
                }
                catch (Exception e)
                {
                    _logger.Error("Sensor Exception occurred for: " + _sensor.GetType());
                    _logger.Error(e);
                    Stop();
                }
            }
        }

        private void Stop()
        {
            _isPolling = false;
        }

        private void Poll()
        { 
            var readings = _sensor.MakeReading();
            foreach (var reading in readings)
            {
                _reporter.Report(reading);
            }
            _logger.Info("Sensor reading reported for: " + _sensor.GetType());
        }
    }
}
