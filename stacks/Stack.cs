using System;

namespace omarkhd.DataStructures
{
	public class Stack<T> : IStack<T>
	{
		private IList<T> InnerList;
		private int Top;

		public Stack(IList<T> list)
		{
			this.InnerList = list;
			this.Clear();
		}

		public Stack() : this(new LinkedList<T>()) {}

		public void Push(T item)
		{
			this.InnerList.Add(item);
			this.Top += 1;
		}

		public bool Empty
		{
			get
			{
				return this.InnerList.Length == 0;
			}
		}

		public int Length
		{
			get
			{
				return this.InnerList.Length;
			}
		}

		public T Peek()
		{
			if(this.Top == -1)
				throw new IndexOutOfRangeException();

			return this.InnerList[this.Top];
		}

		public T Pop()
		{
			if(this.Top == -1)
				throw new IndexOutOfRangeException();

			T item = this.InnerList[this.Top];
			this.InnerList.RemoveAt(this.Top--);
			return item;
		}

		public void Clear()
		{
			this.InnerList.Clear();
			this.Top = -1;
		}
	}
}
