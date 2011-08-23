namespace omarkhd.DataStructures
{
	public interface IQueue<T>
	{
		int Length { get; }
		bool Empty { get; }

		void Enqueue(T item);
		T Dequeue();
		void Clear();
	}
}
