using System;

namespace omarkhd.DataStructures
{
	public class LinkedList<T> : IList<T>
	{
		private LinkedListNode<T> Sentinel;	
		public bool Empty { get { return this.Length == 0; } }
		public int Length { get; private set; }

		public LinkedList()
		{
			this.Clear();
		}

		public void Add(T item)
		{
			LinkedListNode<T> newItem = new LinkedListNode<T>(item);
			LinkedListNode<T> last = this.Sentinel.Previous;

			last.Next = newItem;
			newItem.Previous = last;
			newItem.Next = this.Sentinel;
			this.Sentinel.Previous = newItem;

			this.Length += 1;
		}

		public T Get(int index)
		{
			return this.GetNode(index).Item;
		}

		public void Insert(int index, T item)
		{
			if(index == this.Length)
			{
				this.Add(item);
				return;
			}

			LinkedListNode<T> current = this.GetNode(index);
			LinkedListNode<T> newNode = new LinkedListNode<T>(item);

			current.Previous.Next = newNode;
			newNode.Previous = current.Previous;
			newNode.Next = current;
			current.Previous = newNode;
			this.Length++;
		}

		public bool Remove(T item)
		{
			int index = this.IndexOf(item);
			if(index == -1)
				return false;

			this.RemoveAt(index);
			return true;
		}

		public void RemoveAt(int index)
		{
			LinkedListNode<T> node = this.GetNode(index);
			node.Previous.Next = node.Next;
			node.Next.Previous = node.Previous;
			this.Length -= 1;
		}

		public void Set(int index, T item)
		{
			this.GetNode(index).Item = item;
		}

		public int IndexOf(T item)
		{
			int index;
			LinkedListNode<T> pointer;
			for(pointer = this.Sentinel.Next, index = 0; pointer != this.Sentinel; pointer = pointer.Next, index++)
				if(pointer.Item.Equals(item))
					return index;
			return -1;			
		}

		public T this[int index]
		{
			get
			{
				return this.Get(index);
			}

			set
			{
				if(index == this.Length)
					this.Add(value);
				else
					this.Set(index, value);
			}
		}

		public bool Contains(T item)
		{
			return this.IndexOf(item) != -1;
		}

		private LinkedListNode<T> GetNode(int index)
		{
			if(index < 0 || index >= this.Length)
				throw new IndexOutOfRangeException();

			LinkedListNode<T> pointer = this.Sentinel;
			for(int i = 0; i <= index; i++, pointer = pointer.Next);
			return pointer;
		}

		public void Clear()
		{
			this.Length = 0;
			this.Sentinel = new LinkedListNode<T>();
			this.Sentinel.Previous = this.Sentinel;
			this.Sentinel.Next = this.Sentinel;
		}
	}
}
