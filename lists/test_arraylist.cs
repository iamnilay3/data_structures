using System;
using omarkhd.DataStructures;

class arraylist_test
{
	private static void Main()
	{
		//Console.Out.WriteLine("Testing the array list implementation");
		Console.Out.WriteLine("Testing the linked list implementation");

		IList<int> list = new LinkedList<int>();
		Console.Out.WriteLine("Length: {0}", list.Length);
		//Console.Out.WriteLine("Capacity: {0}", list.Capacity);

		Random r = new Random();
		for(int i = 0; i < 15; i++)
			list.Add(r.Next());
			//list[i] = r.Next();

	
		/*list[14] = 9999999;
		//list.Set(14, 9999999);
		//list.Add(14);
		list.Insert(1, 14);
		//list.Insert(1, 14);

		list.RemoveAt(0);
		list.Remove(4563);
*/
		list.Clear();
		list.Add(14);
		list.Add(57);
		list.Add(43);
		list.Add(84);
		list.Insert(1, 123);
		list[2] = 58;
		list.RemoveAt(1);
		list.Remove(84);
		Console.Out.WriteLine("index of 84: {0}", list.IndexOf(84));
		Console.Out.WriteLine("index of 184: {0}", list.IndexOf(184));
		Console.Out.WriteLine("contains 1843?: {0}", list.Contains(1843));
		PrintList(list);

		/*int x = 14;
		Console.Out.WriteLine("Contains {0}? {1}", x, (list.Contains(x) ? "yes" : "no")); */
	}

	private static void PrintList<T>(IList<T> list)
	{
		for(int i = 0; i < list.Length; i++)
			Console.Out.WriteLine(list[i]);

		Console.Out.WriteLine("Length: {0}", list.Length);
		//Console.Out.WriteLine("Capacity: {0}", list.Capacity);
	}
}
