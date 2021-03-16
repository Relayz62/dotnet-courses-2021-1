using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class GeometricProgression : ISeries
    {
        private int _currentIndex;
        private double _firstElement;
        private double _step;

        public GeometricProgression(double firstElement, double step)
        {
            _firstElement = firstElement;
            _step = step;
            _currentIndex = 0;
        }

        public double GetCurrent()
        {
            double k = _firstElement / _step;
            // return Math.Pow(_firstElement, _currentIndex);
            return _firstElement * Math.Pow(_step, _currentIndex);
        }

        public bool MoveNext()
        {
            _currentIndex++;
            return true;
        }

        public void Reset()
        {
            _currentIndex = 0;
        }
    }
}
