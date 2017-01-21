using System;
using System.Collections.Generic;
using System.Linq;

namespace KasLab.FindPairs.Lib
{
	public class PairsFinder<TItem> : IPairsFinder<TItem>
	{
		private Func<TItem, TItem, bool> _condition;

		public IEnumerable<Pair<TItem>> FindPairs(IEnumerable<TItem> items)
		{
			if(items == null)
				throw new ArgumentNullException(nameof(items));
			if(_condition == null)
				throw new InvalidOperationException("Condition not setted.");
			var itemsArr = items.ToArray();
			for(int i = 0; i < itemsArr.Length-1; i++)
			{
				var item1 = itemsArr[i];
				for (int j=i+1; j < itemsArr.Length; j++)
				{
					var item2 = itemsArr[j];
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