using System;
using System.Collections.Generic;
using System.Linq;

namespace Tarefa2
{
	class Program
	{
		static void Main(string[] args)
		{
			MakeTree(new int[] { 3, 2, 1, 6, 0, 5 });
			Console.WriteLine("\n----------------\n");
			MakeTree(new int[] { 7, 5, 13, 9, 1, 6, 4 });
		}

		/// <summary>
		/// Make a tree of array
		/// </summary>
		/// <param name="input">Array of values</param>
		static void MakeTree(int[] input)
		{
			int root = input.Max();
			List<int> left = new List<int>();
			List<int> right = new List<int>();

			bool rootFinded = false;

			foreach (var item in input)
			{
				if (item == root)
				{
					rootFinded = true;
					continue;
				}

				if (!rootFinded) left.Add(item);
				else right.Add(item);
			}

			left = left.OrderByDescending(x => x).ToList();
			right = right.OrderByDescending(x => x).ToList();

			int rightSpace = 0;

			for (int i = 0; i <= Math.Max(left.Count, right.Count); i++)
			{
				if (i == 0)
				{
					Console.WriteLine(InsertSpace(left.Count) + root.ToString());
					continue;
				}

				string line = "";

				if (left.Count > i - 1)
				{
					line += InsertSpace(left.Count - i) + left[i - 1].ToString();
				}

				if (right.Count > i - 1)
				{
					if (i == 1) rightSpace += root.ToString().Length - 1 + i;
					else if (i == right.Count) rightSpace += left.Count - 1;
					else rightSpace += left.Count;

					line += InsertSpace(rightSpace) + right[i - 1].ToString();
				}

				Console.WriteLine(line);
			}
		}
		
		/// <summary>
		/// Return blank spaces 
		/// </summary>
		/// <param name="length">Lenght of blank spaces</param>
		/// <returns>String with a blank spaces</returns>
		static string InsertSpace(int length)
		{
			string spaces = "";
			for (int i = 0; i < length; i++)
				spaces += " ";

			return spaces;
		}
	}
}
