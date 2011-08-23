using System;
using System.IO;
using omarkhd.DataStructures;

class test1
{
	private static void Main()
	{
		BinarySearchTree<string> tree = new BinarySearchTree<string>();
		long counter = 0, start, end, total = 0;

		//Inserting
		FileStream fs = new FileStream("google.txt", FileMode.Open);
		StreamReader reader = new StreamReader(fs);
		string line = null;
		while((line = reader.ReadLine()) != null)
			foreach(string word in line.Split(' '))
			{
				start = Environment.TickCount;
				tree.Insert(word);
				end = Environment.TickCount;
				total += end - start;
				counter += 1;
			}
		reader.Close();
		Console.Out.WriteLine("time elapsed inserting {0} words: {1} seconds", counter, total / 1000D);
		Console.Out.WriteLine("approx. {0} words per second", counter / (total / 1000D));

		//writing new file
		FileStream fs2 = new FileStream("ordered_words.txt", FileMode.Create, FileAccess.ReadWrite);
		StreamWriter sw = new StreamWriter(fs2);
		start = Environment.TickCount;
		IList<string> list = tree.TraverseToList(TraversalType.Inorder);
		end = Environment.TickCount;
		Console.Out.WriteLine("time elapsed traversing and generating the list for {0} elements: {1} seconds", counter, (end - start) / 1000D);
		Console.Out.Write("writing file...");
		for(int i = 0; i < list.Length; i++)
			sw.WriteLine(list[i]);
		sw.Close();
		Console.Out.WriteLine();

		string c = "Ford";
		string c2 = "created";
		//Console.Out.WriteLine("contains {0}?", c);
		//Console.Out.WriteLine(tree.Contains(c));

		//Console.Out.WriteLine(tree.Search("created"));
		//Console.Out.WriteLine(tree.Remove(c));
		//Console.Out.WriteLine(tree.Remove("Shortly"));
		//Console.Out.WriteLine(tree.Contains(c2));
		//Console.Out.WriteLine(tree.Contains(c));

		list = tree.TraverseToList(TraversalType.BreadthFirst);
		for(int i = 0; i < list.Length; i++)
			Console.Out.WriteLine(list[i]);
	}
}
