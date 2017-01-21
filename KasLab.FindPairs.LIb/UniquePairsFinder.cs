using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KasLab.FindPairs.Lib
{
	public class UniquePairsFinder<TItem> : IPairsFinder<TItem>
	{
		private Func<TItem, TItem, bool> _condition;

		public void SetCondition(Func<TItem, TItem, bool> condittion)
		{
			_condition = condittion;
		}

		public IEnumerable<Pair<TItem>> FindPairs(IEnumerable<TItem> items)
		{
			if (items == null) throw new ArgumentNullException(nameof(items));
			if(_condition == null)
				throw new InvalidOperationException("Condition not set");
			var itemsArr = items.ToList();
			itemsArr.Sort();
			var result = new Collection<Pair<TItem>>();
			TItem lastItem = default(TItem);
			for (int i = 0; i < itemsArr.Count-1; i++)
			{
				var item1 = itemsArr[i];
				if(i != 0 && Equals(lastItem, item1))
					continue;
				for (int j = i + 1; j < itemsArr.Count; j++)
				{
					var item2 = itemsArr[j];
					if (_condition(item1, item2))
					{
						var pair = new Pair<TItem>(item1, item2);
						result.Add(pair);
						break;
					}

				}
				lastItem = item1;
			}
			return result;
		}
	}
}