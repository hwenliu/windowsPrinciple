using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyInterfaces
{
    [Guid("00000000-BB80-4B78-AE68-0C01C966F72D")]
    [ComVisible(true)]
    public interface ICompute
    {
        double add(double a, double b);

        double minus(double a, double b);
    }
}
