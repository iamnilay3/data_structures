using System;
using omarkhd.DataStructures;

class test
{
	private static void Main()
	{
		IQueue<int> queue = new CircularQueue<int>(5);

		/*for(int i = 0; i < 1000000; i++)
			queue.Enqueue(i);

		for(int i = 0; i < 1000000; i++)
			Console.Out.WriteLine(queue.Dequeue());*/

		queue.Enqueue(123);
		queue.Enqueue(234);
		queue.Enqueue(345);
		queue.Enqueue(456);
		queue.Enqueue(567);

		Console.Out.WriteLine("-> " + queue.Dequeue());
		Console.Out.WriteLine("-> " + queue.Dequeue());
		queue.Enqueue(345);

		while(!queue.Empty)
			Console.Out.WriteLine(queue.Dequeue());
	}
}
