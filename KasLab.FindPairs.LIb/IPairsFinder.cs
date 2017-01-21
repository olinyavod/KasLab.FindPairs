using System;
using System.Collections.Generic;

namespace KasLab.FindPairs.LIb
{
    public interface IPairsFinder<TItem>
    {
	    IEnumerable<Pair<TItem>> GetPairs();

	    void SetCondition(Func<TItem, TItem, bool> condittion);
    }

	public class UniquePairsFinder<TItem> : IPairsFinder<TItem>
	{
		public IEnumerable<Pair<TItem>> GetPairs()
		{
			throw new NotImplementedException();
		}

		public void SetCondition(Func<TItem, TItem, bool> condittion)
		{
			throw new NotImplementedException();
		}
	}
}
