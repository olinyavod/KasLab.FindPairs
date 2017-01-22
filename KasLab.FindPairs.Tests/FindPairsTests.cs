using System;
using System.Collections.Generic;
using System.Linq;
using KasLab.FindPairs.Library;
using NUnit.Framework;

namespace KasLab.FindPairs.Tests
{
	[TestFixture]
    public class FindPairsTests
    {
		[Test]
	    public void FindSexteenPairs()
		{
			var items = new[] { 1, 2, 1, 2, 1, 2, 1, 2 };
			var finder = new PairsFinder {PairSum = 3, Source = items};
			var pairs = finder.FindPairs().ToList();
			
			Assert.AreEqual(16, pairs.Count);
		}

		[Test]
	    public void FindOnePairs()
		{
			var items = new[] {9, 9, 9, 9, 1, 1, 9, 9, 9, 9, 9};
			var finder = new PairsFinder {PairSum = 2, Source = items};
			
			var pairs = finder.FindPairs().ToList();

			Assert.AreEqual(1, pairs.Count);
		}

		[Test]
	    public void FindTwoPairs()
	    {
			var items = new[] { 9, 9, 9, 9, 1, 1, 9, 9, 0, 9, 2 };
		    var finder = new PairsFinder {PairSum = 2, Source = items};
			var pairs = finder.FindPairs().ToList();

			Assert.AreEqual(2, pairs.Count);
		}

		[Test]
	    public void FindZeroPairsInZeroCollection()
	    {
		    var finder = new PairsFinder {PairSum = 2, Source = new List<int>()};
		    var pairs = finder.FindPairs().ToList();

			Assert.AreEqual(0, pairs.Count);
	    }

		[Test]
	    public void ShouldBeInvalidOperationEcptionIfSourceIsNull()
	    {
		    var finder = new PairsFinder
		    {
			    PairSum = 2
		    };
		    Assert.Catch<InvalidOperationException>(() => finder.FindPairs().Count());
	    }
    }
}
