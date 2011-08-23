using System;

namespace omarkhd.DataStructures
{
	public interface IList<T>
	{
		//properties
		int Length { get; }
		bool Empty { get; }

		//setters and getters
		void Set(int index, T item);
		T Get(int index);
		T this[int index] { get; set; }

		//methods for populating the list
		void Add(T item);
		void Insert(int index, T item);

		//removing
		bool Remove(T item);
		void RemoveAt(int index);

		//searching
		int IndexOf(T item);
		bool Contains(T item);

		//clear the list
		void Clear();
	}
}
