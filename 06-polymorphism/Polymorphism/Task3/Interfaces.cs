using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
	public interface ISeries
	{
		double GetCurrent();
		bool MoveNext();
		void Reset();
	}
	public interface IIndexable
	{
		double this[int index] { get; }
	}

	interface IIndexableSeries : ISeries, IIndexable
	{

	}
}
