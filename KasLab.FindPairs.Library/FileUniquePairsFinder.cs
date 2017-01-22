using System.Collections.Generic;
using System.IO;
using CodeBits;

namespace KasLab.FindPairs.Library
{
	public class FileUniquePairsFinder : IPairsFinder, IFileSource
	{
		public int PairSum { get; set; }
		
		public IEnumerable<Pair<int>> FindPairs()
		{
			var collection = CreateSortedCollection();
			int? lastItem = null;
			for (int i = 0; i < collection.Count - 1; i++)
			{
				var item1 = collection[i];
				if (item1 > PairSum)
					break;
				if (Equals(lastItem, item1))
					continue;
				for (int j = i + 1; j < collection.Count; j++)
				{
					var item2 = collection[j];
					if (item2 > PairSum && item1 > 0) break;

					if ((item1 + item2) == PairSum)
					{
						var pair = new Pair<int>(item1, item2);
						yield return pair;
						break;
					}

				}
				lastItem = item1;
			}
		}

		IList<int> CreateSortedCollection()
		{
			var result = new OrderedCollection<int>(true, false);
			using (var reader = CreateReader())
			{
				
				while (!reader.EndOfStream)
				{
					int i;
					if (int.TryParse(reader.ReadLine(), out i))
					{
						var currentIndex = result.IndexOf(i);
						if (currentIndex > -1)
						{
							var nextIndex = currentIndex + 1;
							if(result.Count > nextIndex && result[nextIndex] == i)
								continue;
							result.Add(i);

						}
						else result.Add(i);
					}
				}
			}
			return result;
		}

		

		StreamReader CreateReader()
		{
			return new StreamReader(Path, true);
		}

		public string Path { get; set; }
	}
}
