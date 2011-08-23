using System;

namespace omarkhd.DataStructures
{
	public class CircularQueue<T> : IQueue<T>
	{
		private T[] InnerArray;
		public int Capacity { get; private set; }
		public int Length { get; private set; }
		private int Front;
		private int Rear;

		public CircularQueue(int size)
		{
			this.Capacity = size;
			this.Clear();
		}

		public void Enqueue(T item)
		{
			if(this.Length >= this.Capacity)
				throw new IndexOutOfRangeException();

			if(this.Rear == this.Capacity)
				this.Rear = 0;

			this.InnerArray[Rear++] = item;
			this.Length += 1;
		}

		public T Dequeue()
		{
			if(this.Length == 0)
				throw new IndexOutOfRangeException();

			if(this.Front == this.Capacity - 1)
				this.Front = -1;

			this.Length -= 1;
			T item = this.InnerArray[++this.Front];
			this.InnerArray[this.Front] = default(T);
			return item;
		}

		public void Clear()
		{
			this.InnerArray = new T[this.Capacity];
			this.Front = -1;
			this.Rear = 0;
			this.Length = 0;
		}

		public bool Empty
		{
			get
			{
				return this.Length == 0;
			}
		}
	}
}
