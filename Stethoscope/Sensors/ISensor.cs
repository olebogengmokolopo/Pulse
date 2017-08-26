using System.Collections.Generic;
using Common.Sensors;

namespace Stethoscope.Sensors
{
    public interface ISensor<out T> where T : ISensorReading
    {
        IEnumerable<T> MakeReading();
    }
}
