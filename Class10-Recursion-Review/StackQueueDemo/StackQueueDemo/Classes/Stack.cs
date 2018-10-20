using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueDemo.Classes
{
	public class Stack
	{
		public Node Top { get; set; }

		public Stack(Node node)
		{
			Top = node;
		}

		//Peek
		public Node Peek()
		{
			// this is a great place for a try/catch (if you want)
			return Top;
		}

		//Pop
		public Node Pop()
		{
			Node temp = Peek();
			Top = Top.Next;
			temp.Next = null;
			return temp;
		}
		//Push
		public void Push(Node node)
		{
			node.Next = Top;
			Top = node;
		}
	}
}
