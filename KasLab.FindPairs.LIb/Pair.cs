using System;

namespace KasLab.FindPairs.LIb
{
	public struct Pair<TItem>
	{
		public Pair(TItem item1, TItem item2)
		{
			Item1 = item1;
			Item2 = item2;
		}

		public TItem Item1 { get; set; }

		public TItem Item2 { get; set; }
	}
}