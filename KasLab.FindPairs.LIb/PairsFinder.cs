using System;
using System.Collections.Generic;
using System.Linq;

namespace KasLab.FindPairs.LIb
{
	public class PairsFinder<TItem> : IPairsFinder<TItem>
	{
		private readonly TItem[] _items;
		private Func<TItem, TItem, bool> _condition;

		public PairsFinder(IEnumerable<TItem> items)
		{
			_items = items.ToArray();
		}

		public IEnumerable<Pair<TItem>> GetPairs()
		{
			if(_items == null)
				throw new InvalidOperationException("Collection is null");
			if(_condition == null)
				throw new InvalidOperationException("Condition not setted.");
			for(int i = 0; i < _items.Length-1; i++)
			{
				for (int j=i+1; j < _items.Length; j++)
				{
					var item1 = _items[i];
					var item2 = _items[j];
					if (_condition(item1, item2))
						yield return new Pair<TItem>(item1, item2);
				}
			}
		}

		public void SetCondition(Func<TItem, TItem, bool> condittion)
		{
			_condition = condittion;
		}
	}
}