using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasLab.FindPairs.Lib;

namespace KasLab.FindPairs.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			IPairsFinder _finder;
			do
			{
				System.Console.Clear();
				System.Console.WriteLine("Hi, this program searches pairs such as (n[i] + n[j] == x)");
				System.Console.Write("Select type pairs (1 - Unique, 2 - All, Q - Quit): ");
				var key = System.Console.ReadKey(false);
				System.Console.WriteLine();
				if (key.KeyChar == '1')
				{
					_finder = new UniquePairsFinder();
					System.Console.WriteLine("Selected Unique search pairs.");
				}
				else if (key.KeyChar == '2')
				{
					_finder = new PairsFinder();
					System.Console.WriteLine("Selected search all pairs.");
				}
				else if (key.Key == ConsoleKey.Q) break;
				else continue;

				int sum;
				do
				{
					System.Console.Write("Enter sum of pairs: ");
				} while (!int.TryParse(System.Console.ReadLine(), out sum));
				_finder.PairSum = sum;


				System.Console.Write("Enter collection: ");
				var items = new List<int>();
				foreach (var item in (System.Console.ReadLine() ?? "").Split(new[] {',', ' ', ';'}, StringSplitOptions.RemoveEmptyEntries))
				{
					int v;
					if (int.TryParse(item, out v))
					{
						items.Add(v);
					}
				}
				System.Console.WriteLine("Your collection: {0}", string.Join(", ", items));
				var pairs = _finder.FindPairs(items).ToList();
				System.Console.WriteLine("Pairs: {0}", string.Join(", ", pairs));
				System.Console.WriteLine("Pairs count: {0}", pairs.Count);
				System.Console.Write("Press any key for continue or Q for exit...");
				key = System.Console.ReadKey(true);
				if(key.Key == ConsoleKey.Q)
					break;

			} while (true);
		}


	}
}
