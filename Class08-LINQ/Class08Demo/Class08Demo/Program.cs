using Class08Demo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Class08Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			//ListExample();
			LINQExample();
		}

		static void ListExample()
		{
			List<Pogs> pogs = new List<Pogs>()
			{
				new Pogs{Color=Color.Red, Name = "The Pog"},
				new Pogs{Color=Color.Blue, Name = "Cat's Pog"},
				new Pogs{Color=Color.Green, Name = "Goober"},
				new Pogs{Color=Color.Purple},

			};

			foreach (var item in pogs)
			{

				Console.WriteLine(item.Name);
			}
		}

		static void LINQExample()
		{
			string[] myCats = { "Josie", "Belle", "Kimchi", "Matilda", "Honey", "Frodo" };

			IEnumerable<string> myStrings = from cat in myCats
											where cat.Contains("i")
											select cat;

			var secondFilter = from y in myStrings
							   where y.Length == 5
							   select y;

			foreach (var item in myStrings)
			{
				Console.WriteLine(item);

			}

			Console.WriteLine("=========");

			foreach (var item in secondFilter)
			{

				Console.WriteLine(item);
			}
			//var myFilteredCats = 

			Console.WriteLine("==========");


			List<string> myList = new List<string>
			{
				"cat", "dog", "bird", "ox"
			};

			IEnumerable<string> myAnimals = from animal in myList
											where animal.Length <= 3
											select animal;

			var result = myList.Where(x => x.Length <= 3);

			foreach (var item in myAnimals)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("=========");
			foreach (var item in result)
			{
				Console.WriteLine(item);
			}
		}
	}
}
