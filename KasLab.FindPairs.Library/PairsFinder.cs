using System;
using System.Collections.Generic;
using System.Linq;

namespace KasLab.FindPairs.Library
{
	public class PairsFinder : IPairsFinder
	{
		public IEnumerable<Pair<int>> FindPairs(IEnumerable<int> items)
		{
			if(items == null)
				throw new ArgumentNullException(nameof(items));
			var itemsArr = items.ToArray();
			for(int i = 0; i < itemsArr.Length-1; i++)
			{
				var item1 = itemsArr[i];
				for (int j = i + 1; j < itemsArr.Length; j++)
				{
					var item2 = itemsArr[j];
					if ((item1 + item2) == PairSum)
						yield return new Pair<int>(item1, item2);
				}
			}
		}

		public int PairSum { get; set; }
	}
}