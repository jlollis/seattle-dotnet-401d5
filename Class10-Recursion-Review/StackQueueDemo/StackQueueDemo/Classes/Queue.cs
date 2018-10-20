namespace StackQueueDemo.Classes
{
	public class Queue
	{
		public Node Front { get; set; }
		public Node Rear { get; set; }

		public Queue(Node node)
		{
			Front = node;
			Rear = node;
		}

		// Peek
		public Node Peek()
		{
			return Front;
		}

		// Enqueue
		public void Enqueue(Node node)
		{
			Rear.Next = node;
			Rear = node;
		}

		// Dequeue
		public Node Dequeue()
		{
			Node temp = Front;
			Front = Front.Next;
			temp.Next = null;
			return temp;
		}
	}
}
