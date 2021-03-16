using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
	public class ArithmeticalProgression : IIndexableSeries
	{
		double start, step;
		int currentIndex;

		public ArithmeticalProgression(double start, double step)
		{
			this.start = start;
			this.step = step;
			this.currentIndex = 0;
		}

		public double this[int index] => start + step * index;

		public double GetCurrent()
		{
			return start + step * currentIndex;
		}

		public bool MoveNext()
		{
			currentIndex++;
			return true;
		}

		public void Reset()
		{
			currentIndex = 0;
		}
	}
}
