using System;

namespace omarkhd.DataStructures
{
	public class ArrayList<T> : IList<T>
	{
		private static readonly int DEFAULT_INITIAL_CAPACITY = 8;
		private readonly int INITIAL_CAPACITY;

		public int Length { get; private set; }
		public int Capacity { get { return this.InnerArray.Length; } }
		public bool Empty { get { return this.Length == 0; } }

		private T[] InnerArray;

		//constructor leaving the user to set the initial capacity
		public ArrayList(int initCapacity)
		{
			this.INITIAL_CAPACITY = initCapacity;
			this.Clear();
		}

		public ArrayList() : this(DEFAULT_INITIAL_CAPACITY) {} //this constructor sets the default initial capacity
		
		//clear method, used to initialize the list
		public void Clear()
		{
			this.InnerArray = new T[this.INITIAL_CAPACITY];
			this.Length = 0;
		}

		public void Add(T item)
		{
			this.EnsureCapacity(this.Length + 1);
			this.InnerArray[this.Length++] = item;
		}

		public T Get(int index)
		{
			if(index < 0 || index >= this.Length)
				throw new IndexOutOfRangeException();

			return this.InnerArray[index];
		}

		public void Set(int index, T item)
		{
			if(index < 0 || index >= this.Length)
				throw new IndexOutOfRangeException();

			this.InnerArray[index] = item;
		}

		//this method inserts an item between other items
		//it allows to insert at the end, just like an Add()
		public void Insert(int index, T item)
		{
			if(index < 0 || index > this.Length)
				throw new IndexOutOfRangeException();

			if(index == this.Length)
				this.Add(item);
			else
			{
				this.EnsureCapacity(this.Length + 1);
				for(int i = this.Length; i > index; i--)
					this.InnerArray[i] = this.InnerArray[i - 1];
				this.InnerArray[index] = item;
				this.Length++;
			}
		}

		//the indexer allows to access to any position of the list (0 to this.Length - 1) and
		//allows to set the last position (this.Length) for practicity
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

		public void RemoveAt(int index)
		{
			if(index < 0 || index >= this.Length)
				throw new IndexOutOfRangeException();

			for(int i = index; i < this.Length - 1; i++)
				this.InnerArray[i] = this.InnerArray[i + 1];

			this.InnerArray[--this.Length] = default(T);
		}

		//this is the core algorithm for searching, its search is based on the Equals() method
		//provided by the object type, that is, it searches based on reference for classes
		//and based on its value, if the underlying type is a value type
		public int IndexOf(T item)
		{
			for(int i = 0; i < this.Length; i++)
				if(this.InnerArray[i].Equals(item))
					return i;
			return -1;
		}

		public bool Remove(T item)
		{
			int index = this.IndexOf(item);
			if(index != -1)
				this.RemoveAt(index);

			return (index == -1 ? false : true);
		}

		public bool Contains(T item)
		{
			return this.IndexOf(item) != -1;
		}

		//this method ensure that the underlying array has the capacity to hold the required length
		private void EnsureCapacity(int required)
		{
			if(this.Capacity - required == 0)
			{
				T[] temp = new T[required + required / 2];
				for(int i = 0; i < this.Length; i++)
					temp[i] = this.InnerArray[i];

				this.InnerArray = temp;
			}
		}
	}
}
