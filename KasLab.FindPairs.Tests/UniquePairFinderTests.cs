using System;
using System.Collections.Generic;
using System.Linq;
using KasLab.FindPairs.Library;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace KasLab.FindPairs.Tests
{
	[TestFixture]
	public class UniquePairFinderTests
	{
		[Test]
		public void FindOnePairBetweenManyPairs()
		{
			var items = new[] { 1, 2, 1, 2, 1, 2, 1, 2 };
			var finder = new UniquePairsFinder {PairSum = 3, Source = items};
			var pairs = finder.FindPairs().ToList();

			Assert.AreEqual(1, pairs.Count, string.Join(";" , pairs));
		}

		[Test]
		public void FindOnePairs()
		{
			var items = new[] { 9, 9, 9, 9, 1, 1, 9, 9, 9, 9, 9 };
			var finder = new UniquePairsFinder {PairSum = 2, Source = items};
			var pairs = finder.FindPairs().ToList();

			Assert.AreEqual(1, pairs.Count);
		}

		[Test]
		public void FindTwoPairs()
		{
			var items = new[] { 9, 9, 9, 9, 1, 1, 9, 9, 0, 9, 2, 0, 2, 1, 1 };
			var finder = new UniquePairsFinder {PairSum = 2, Source = items};
			var pairs = finder.FindPairs().ToList();

			Assert.AreEqual(2, pairs.Count, string.Join(";", pairs));
		}

		[Test]
		public void FindZeroPairsInZeroCollection()
		{
			var finder = new UniquePairsFinder {PairSum = 2, Source = new List<int>()};
			var pairs = finder.FindPairs().ToList();

			Assert.AreEqual(0, pairs.Count);
		}

		[Test]
		public void FindPairsInNegativeNumbers()
		{
			var items = new[] { 9, 9, 9, 9, -1, 1, 9, 9, 0, 9, -2, 0, 2, 1, 1 };
			var finder = new UniquePairsFinder { PairSum = 0, Source = items};
			var pairs = finder.FindPairs().ToList();

			Assert.AreEqual(3, pairs.Count, string.Join(";", pairs));
		}

		[Test]
		public void FindPairsInAllNegativeNumbers()
		{
			var items = new[] { -9, -9, -9, -9, -1, -1, -9, -9, 0, -9, -2, 0, -2, -1, -1 };
			var finder = new UniquePairsFinder { PairSum = 0, Source = items};
			var pairs = finder.FindPairs().ToList();

			Assert.AreEqual(1, pairs.Count, string.Join(";", pairs));
		}

		[Test]
		public void ShouldBeInvalidOperationExceptionIfSourceIsNull()
		{
			var finder = new PairsFinder();
			finder.PairSum = 2;
			Assert.Catch<InvalidOperationException>(() => finder.FindPairs().Count());
		}

		
	}
}
