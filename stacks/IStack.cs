namespace omarkhd.DataStructures
{
	public interface IStack<T>
	{
		bool Empty { get; }
		int Length {get; }

		T Pop();
		T Peek();
		void Push(T item);
		void Clear();
	}
}
