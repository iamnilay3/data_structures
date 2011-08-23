using System;
using omarkhd.DataStructures;

class test
{
	private static void Main()
	{
		Stack<string> stack = new Stack<string>();
		stack.Push("cornejo");
		stack.Push("qweqwe");
		stack.Pop();
		stack.Push("martín");
		stack.Push("karim");
		stack.Push("omar");

		while(!stack.Empty)
			Console.Out.WriteLine(stack.Pop());
	}
}
