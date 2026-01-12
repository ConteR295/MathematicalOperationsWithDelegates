using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalOperationsWithDelegates.Models
{
    internal class IsItPrime
    {
        public Predicate<double> IsPrime = (double a) =>
        {
            for (long i = 2; i <= Math.Sqrt(a); i++)
                if (a % i == 0)
                    return false;
            return true;
        };
    }
}
