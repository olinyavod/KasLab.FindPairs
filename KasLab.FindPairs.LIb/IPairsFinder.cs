using System;
using System.Collections.Generic;

namespace KasLab.FindPairs.Lib
{
    public interface IPairsFinder<TItem>
    {
	    IEnumerable<Pair<TItem>> FindPairs(IEnumerable<TItem> items);

	    void SetCondition(Func<TItem, TItem, bool> condittion);
    }
}
