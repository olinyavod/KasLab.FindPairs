using System;
using System.Collections.Generic;

namespace KasLab.FindPairs.Lib
{
    public interface IPairsFinder
    {
		int PairSum { get; set; }

	    IEnumerable<Pair<int>> FindPairs(IEnumerable<int> items);
    }
}
