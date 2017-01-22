using System;
using System.Collections.Generic;
using System.Linq;

namespace KasLab.FindPairs.Library
{
	public class UniquePairsFinder : IPairsFinder, ICollectionSource
	{
		public IEnumerable<Pair<int>> FindPairs()
		{
			if (Source == null) throw new InvalidOperationException("Source not setted");
			var itemsArr = Source.ToList();
			itemsArr.Sort();
			int? lastItem = null;
			for (int i = 0; i < itemsArr.Count-1; i++)
			{
				var item1 = itemsArr[i];
				if(item1 > PairSum)
					break;
				if(Equals(lastItem, item1))
					continue;
				for (int j = i + 1; j < itemsArr.Count; j++)
				{
					var item2 = itemsArr[j];
					if (item2 > PairSum && item1 > 0) break;

					if ((item1+item2)==PairSum)
					{
						var pair = new Pair<int>(item1, item2);
						yield return pair;
						break;
					}

				}
				lastItem = item1;
			}
		}

		public int PairSum { get; set; }

		public IList<int> Source { get; set; }
	}
}