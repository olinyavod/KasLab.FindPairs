using System;
using System.Collections.Generic;

namespace KasLab.FindPairs.Library
{
	public class PairsFinder : IPairsFinder, ICollectionSource
	{
		public IEnumerable<Pair<int>> FindPairs()
		{
			if(Source == null)
				throw new InvalidOperationException("Source not setted");
			for(int i = 0; i < Source.Count-1; i++)
			{
				var item1 = Source[i];
				for (int j = i + 1; j < Source.Count; j++)
				{
					var item2 = Source[j];
					if ((item1 + item2) == PairSum)
						yield return new Pair<int>(item1, item2);
				}
			}
		}

		public int PairSum { get; set; }

		public IList<int> Source { get; set; }
	}
}