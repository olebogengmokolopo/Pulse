using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stethoscope.Sensors
{
    public interface ISensor<T>
    {
        IEnumerable<T> MakeReading();
    }
}
