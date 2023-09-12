using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyInterfaces
{
    [Guid("22222222-DBEF-43DE-80F4-394703BD3D41")]
    [ComVisible(true)]
    public class MyCompute2 : ICompute
    {
        public double add(double a, double b)
        {
            return a * b;
        }

        public double minus(double a, double b)
        {
            return a / b;
        }
    }
}
