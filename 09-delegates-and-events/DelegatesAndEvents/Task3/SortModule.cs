using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task3
{
    class SortModule
    {
        public event EventHandler SortingFinished;
        public delegate int StringComparer(string first, string second);

        public Thread SortAsync(string[] array, StringComparer stringComparer)
        {
            stringComparer += CompareStrings;
            for (int i = 0; i < array.Length - 1; i++)
            {
                switch (stringComparer(array[i], array[i + 1]))
                {
                    case 0:
                        Array.Sort<string>(array, (first, second) => string.Compare(first, second));
                        break;
                    case 1:
                        string temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        break;
                }
            }
            stringComparer -= CompareStrings;
            SortingFinished?.Invoke(this, EventArgs.Empty);
            return Thread.CurrentThread;
        }
        public int CompareStrings(string first, string second)
        {
            if (first.Length > second.Length) return -1;
            if (first.Length < second.Length) return 1;
            return 0;
        }

        public void CreateThreadForSorting(string[] array, StringComparer stringComparer)
        {
            Thread th = new Thread(() => SortAsync(array, stringComparer));
            th.Start();
        }
    }
}
