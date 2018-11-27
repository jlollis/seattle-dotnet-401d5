using System;
using System.Collections.Generic;

namespace GraphClassDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		static public void AddNodes()
		{
			LinkedList<Tuple<Node, int>> NodeA = new LinkedList<Tuple<Node, int>>();
			LinkedList<Tuple<Node, int>> NodeB = new LinkedList<Tuple<Node, int>>();
			LinkedList<Tuple<Node, int>> NodeC = new LinkedList<Tuple<Node, int>>();


			NodeA.AddFirst(new Tuple<Node, int>(new Node { Value = "cat" }, 10 ));

			Graph graph = new Graph();
			graph.AdjacencyList.AddFirst(NodeA);
		}
	}
}
