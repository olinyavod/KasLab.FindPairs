﻿using System;
using System.Linq;
using KasLab.FindPairs.Lib;
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
			var finder = new UniquePairsFinder<int>();
			finder.SetCondition((x, y) => x + y == 3);
			var pairs = finder.FindPairs(items).ToList();

			Assert.AreEqual(1, pairs.Count, string.Join(";" , pairs));
		}

		[Test]
		public void FindOnePairs()
		{
			var items = new[] { 9, 9, 9, 9, 1, 1, 9, 9, 9, 9, 9 };
			var finder = new UniquePairsFinder<int>();
			finder.SetCondition((x, y) => x + y == 2);
			var pairs = finder.FindPairs(items).ToList();

			Assert.AreEqual(1, pairs.Count);
		}

		[Test]
		public void FindTwoPairs()
		{
			var items = new[] { 9, 9, 9, 9, 1, 1, 9, 9, 0, 9, 2, 0, 2, 1, 1 };
			var finder = new UniquePairsFinder<int>();
			finder.SetCondition((x, y) => x + y == 2);
			var pairs = finder.FindPairs(items).ToList();

			Assert.AreEqual(2, pairs.Count, string.Join(";", pairs));
		}

		[Test]
		public void FindZeroPairsInZeroCollection()
		{
			var finder = new UniquePairsFinder<int>();
			finder.SetCondition((x, y) => x + y == 2);
			var pairs = finder.FindPairs(new int[0]).ToList();

			Assert.AreEqual(0, pairs.Count);
		}

		[Test]
		public void ShouldBeArgumentNullExceptionIfCollectionIsNull()
		{
			var finder = new PairsFinder<int>();
			finder.SetCondition((x, y) => x + y == 2);
			Assert.Catch<ArgumentNullException>(() => finder.FindPairs(null).Count());
		}

		[Test]
		public void ShouldBeInvalidOperationIfNotSetCondition()
		{
			var finder = new PairsFinder<int>();
			Assert.Catch<InvalidOperationException>(() => finder.FindPairs(new int[0]).Count());
		}
	}
}