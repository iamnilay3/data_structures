using System;

namespace omarkhd.DataStructures
{
	public class Queue<T> : IQueue<T>
	{
		private IList<T> InnerList;

		public int Length
		{
			get
			{
				return this.InnerList.Length;
			}
		}

		public bool Empty
		{
			get
			{
				return this.InnerList.Empty;
			}
		}

		public Queue(IList<T> list)
		{
			this.InnerList = list;
		}

		public Queue() : this(new LinkedList<T>()) {}

		public void Enqueue(T item)
		{
			this.InnerList.Add(item);
		}

		public T Dequeue()
		{
			if(this.InnerList.Length == 0)
				throw new IndexOutOfRangeException();

			T item = this.InnerList[0];
			this.InnerList.RemoveAt(0);
			return item;
		}

		public void Clear()
		{
			this.InnerList.Clear();
		}
	}
}
