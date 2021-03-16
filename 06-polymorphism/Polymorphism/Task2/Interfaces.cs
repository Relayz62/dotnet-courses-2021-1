using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
	public interface ISeries
	{
		double GetCurrent();
		bool MoveNext();
		void Reset();
	}
}
