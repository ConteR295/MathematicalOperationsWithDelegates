using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalOperationsWithDelegates
{
    public class Publisher
    {
        public event Action<string> OnNotify;

        public void Trigger(string message)
        {
            OnNotify?.Invoke(message);
        }
    }
}
