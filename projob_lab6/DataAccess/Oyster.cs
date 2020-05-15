using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Oyster is a website with reviews of various holiday destinations.
namespace TravelAgencies.DataAccess
{
	public class BSTNode
	{
		public string Review { get; set; }
		public string UserName { get; set; }
		public BSTNode Left { get; set; }
		public BSTNode Right { get; set; }
	}
	class OysterDatabase : MyIteratorAggregate<BSTNode>
	{
		public BSTNode Reviews { get; set; }

		public MyIterator<BSTNode> GetMyEnumerator()
		{
			return new OysterDatabaseIterator(Reviews);
		}
	}
	class OysterDatabaseIterator : MyIterator<BSTNode>
	{
		BSTNode head;
		Stack<BSTNode> stack = new Stack<BSTNode>();
		public OysterDatabaseIterator(BSTNode Reviews)
		{
			head = Reviews;
			pushToLeft(Reviews);
		}

		public BSTNode GetNext()
		{
			BSTNode node = stack.Pop();
			pushToLeft(node.Right);
			return node;
		}

		public bool HasNext()
		{
			if (stack.Count != 0)
			{
				return true;
			}
			else
			{
				Reset();
				return false;
			}
		}

		public void Reset() { 
			stack.Clear(); 
			pushToLeft(head);
		}

		private void pushToLeft(BSTNode node)
		{
			if (node != null)
			{
				stack.Push(node);
				pushToLeft(node.Left);
			}
		}
	}
}
