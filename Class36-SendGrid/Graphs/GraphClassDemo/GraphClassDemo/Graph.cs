using System;
using System.Collections.Generic;
using System.Text;

namespace GraphClassDemo
{
	class Graph
	{
		public LinkedList<LinkedList<Tuple<Node,int>>> AdjacencyList { get; set; }

		public Graph()
		{
			AdjacencyList = new LinkedList<LinkedList<Tuple<Node, int>>>();
		}

		//AddEdge
		public void AddEdge(Node parent, Tuple<Node,int> child )
		{
			foreach (var item in AdjacencyList)
			{
				var node = item.First.Value.Item1;
				var tuple = item.First.Value.Item2;

			}
		}

		public void AddEdge(Node node)
		{

		}
	}
}
