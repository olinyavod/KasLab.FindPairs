using System.Collections.Generic;

namespace KasLab.FindPairs.Library
{
	public interface ICollectionSource
	{
		IList<int> Source { get; set; }
	}
}