﻿namespace KasLab.FindPairs.Library
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

		public override string ToString()
		{
			return string.Format("({0},{1})", Item1, Item2);
		}
	}
}