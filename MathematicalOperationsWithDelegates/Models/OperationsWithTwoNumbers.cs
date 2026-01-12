using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MathematicalOperationsWithDelegates.Models
{
    internal class OperationsWithTwoNumbers
    {
        public void Execute(double a, double b, Action<double, double> operation)
        {
            operation(a, b);
        }

        public void Add(double a, double b, Action<string> callback)
            => callback((a + b).ToString());

        public void Subtract(double a, double b, Action<string> callback)
            => callback((a - b).ToString());

        public void Multiply(double a, double b, Action<string> callback)
            => callback((a * b).ToString());

        public void Divide(double a, double b, Action<string> callback)
        {
            if (b == 0)
            {
                callback("Ошибка: деление на ноль");
                return;
            }

            callback((a / b).ToString());
        }
    }
}
