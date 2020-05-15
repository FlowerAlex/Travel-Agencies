using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencies.DataAccess
{
	public class ListNode
	{
		public ListNode Next { get; set; }
		public string Name { get; set; }
		public string Rating { get; set; }//Encrypted
		public string Price { get; set; }//Encrypted
	}
	class BookingDatabase : MyIteratorAggregate<ListNode>
	{
		public ListNode[] Rooms { get; set; }

		public MyIterator<ListNode> GetMyEnumerator()
		{
			return new BookingDatabaseIterator(Rooms);
		}
	}


	class BookingDatabaseIterator : MyIterator<ListNode>
	{
		ListNode[] Rooms;
		int actualIndex;
		int levelIndex;
		
		public BookingDatabaseIterator(ListNode[] Rooms)
		{
			this.Rooms = Rooms;
			actualIndex = -1;
			levelIndex = 0;
		}

		public ListNode GetNext()
		{

			for (int j = 1; ; j++)
			{
				ListNode tmp = Rooms[(actualIndex + j) % Rooms.Length];
				bool breaked = false;
				int i;
				for (i = levelIndex + (actualIndex + j) / Rooms.Length; i >= 0; i--)
				{
					if (tmp.Next != null)
					{
						tmp = tmp.Next;
					}
					else
					{
						breaked = true;
						break;
					}
				}
				if (!breaked)
				{
					actualIndex = (actualIndex + j) % Rooms.Length;
					levelIndex = i;
					return tmp;
				}
			}
		}
		public bool HasNext()
		{

			int count = 0;
			for(int j = 1;count < Rooms.Length; j++)
			{
				ListNode tmp = Rooms[(actualIndex + j)%Rooms.Length];
				bool breaked = false;
				for(int i = levelIndex + (actualIndex + j)/Rooms.Length; i>=0; i--)
				{

					if (tmp.Next != null)
					{
						tmp = tmp.Next;
					}
					else
					{
						count++;
						breaked = true;
						break;
					}

				}
				if (!breaked)
				{
					return true;
				}
			}
			Reset();

			return false;
			
		}

		public void Reset()
		{
			actualIndex = -1;
			levelIndex = 0;
		}
	}
}
