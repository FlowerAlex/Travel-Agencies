using System.Collections;

namespace TravelAgencies.DataAccess
{
	public interface MyIterator<T>
	{
		T GetNext();
		bool HasNext();
		void Reset();

	}

	public interface MyIteratorAggregate<T>
	{
		MyIterator<T> GetMyEnumerator();
	}
	class ArrayIterator<T> : MyIterator<T>
	{
		int actualIndex;
		T[] array;
		public ArrayIterator(T[] array){
			actualIndex = -1;
			this.array = array;
		}
		public T GetNext()
		{
			return array[++actualIndex];
		}

		public bool HasNext()
		{
			if(actualIndex + 1< array.Length)
			{
				return true;
			}
			else
			{
				Reset();
				return false;
			}
		}

		public void Reset()
		{
			actualIndex = -1;
		}
	}
}
