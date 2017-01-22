using System.Collections.Generic;

namespace KasLab.FindPairs.Library
{
    public interface IPairsFinder
    {
		int PairSum { get; set; }

	    IEnumerable<Pair<int>> FindPairs(IEnumerable<int> items);
    }
}
