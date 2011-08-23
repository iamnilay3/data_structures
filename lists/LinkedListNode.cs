using System;

namespace omarkhd.DataStructures
{
	class LinkedListNode<T>
	{
		public LinkedListNode<T> Previous;
		public LinkedListNode<T> Next;
		public T Item;

		public LinkedListNode(T item)
		{
			this.Item = item;
		}

		public LinkedListNode() {}
	}
}
