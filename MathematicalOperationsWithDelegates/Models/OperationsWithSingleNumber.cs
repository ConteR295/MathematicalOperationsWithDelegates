using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalOperationsWithDelegates.Models
{
    internal class OperationsWithSingleNumber
    {
        public Func<double,double> ToDouble = (a) => a * 2;
        public Func<double, double> ToSquare = (a) => a * a;
    }
}
