using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task3
{
    public class SortModule
    {
        public event EventHandler SortFinished;
        private void Sort(string[] array, Func<string, string, int> stringComparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    ref string first = ref array[j];
                    ref string second = ref array[j + 1];
                    if (stringComparer(first, second) > 0)
                    {
                        (first, second) = (second, first);
                    }
                }
            }
            SortFinished?.Invoke(this, EventArgs.Empty);
        }

        public Thread SortAsync(string[] array, Func<string, string, int> stringComparer)
        {
            Thread thread = new Thread(() => Sort(array, stringComparer));
            thread.Start();
            return thread;
        }
    }
}

