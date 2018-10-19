using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Class09Demo.Classes;
using Newtonsoft.Json;

namespace Class09Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			//LinqExample();
			//LambdaExpressions();
			JsonConversion();
		}

		static void JsonConversion()
		{
			string path = "../../../most_popular_quotes.json";
			string text = "";

			// using streamreader to access the file. 
			using (StreamReader sr = File.OpenText(path))
			{
				// get all the text
				text = sr.ReadToEnd();
			}

			// deserialize the JSON to convert to the Quotes object. 
			List<Quotes> myQuotes = JsonConvert.DeserializeObject<List<Quotes>>(text);


			// Lambda expression to get all the quotes from 
			// Dr. Seuss.
			var drSeuss = myQuotes.Where(x => x.Author == "Dr. Seuss");

			foreach (var item in drSeuss)
			{
				if(item.Author == "Dr. Seuss")
				{
					Console.WriteLine(item.Text);
				}
			}


		}

		static void LinqExample()
		{
			List<int> myNumbers = new List<int>() { 4, 8, 15, 16, 23, 42, 54, 67, 89, 111 };

			// LINQ query to get the even value of the myNumbers list.

			IEnumerable<int> answer = from result in myNumbers
									  where result % 2 == 0
									  select result;

			foreach (int item in answer)
			{
				Console.WriteLine(item);
			}


			Console.WriteLine("============");

			// Chaining to get the values from prev linq quer less than 20
			List<int> lessThan20 = (from result in answer
									where result < 20
									select result).ToList<int>();

			foreach (var item in lessThan20)
			{
				Console.WriteLine(item);
			}


			Console.WriteLine("SORT DESCENDING");

			List<int> newNumbers = new List<int>() { 1, 11, 1, 31, 1, 31, 10, 22, 35, 11, 31, 76, 56, 10 };

			// LINQ query to sort by descending
			var sortDesc = from results in newNumbers
						   orderby results descending
						   select results;

			foreach (var item in sortDesc)
			{
				Console.WriteLine(item);
			}


			Console.WriteLine("=======Group By==========");

			// LINQ query to get unique values by grouping them together
			var groupping = from num in newNumbers
							group num by num;

			foreach (var item in groupping)
			{
				Console.WriteLine(item.Key);
			}


			var getDistinct = (from number in newNumbers
							   select number).Distinct();


			Console.WriteLine("GET DISTINCT");
			foreach (var item in getDistinct)
			{
				Console.WriteLine(item);
			}





		}

		static void LambdaExpressions()
		{
			List<int> newNumbers = new List<int>() { 1, 11, 1, 31, 1, 31, 10, 22, 35, 11, 31, 76, 56, 10 };

			// Lambda Expression to get all the even numbers
			var answer = newNumbers.Where(x => x % 2 == 0);

			foreach (var item in answer)
			{
				Console.WriteLine(item);
			}


			Console.WriteLine("============");

			// Lambda expression of chaining from prev query to get 
			// values less than 20
			var lessThan20 = answer.Where(y => y < 20);

			foreach (var item in lessThan20)
			{
				Console.WriteLine(item);
			}


			Console.WriteLine("===========UNIQUE===========");

			// Lambda expression to multiply all the numbers by 2
			// get unique off of the multiplied values
			// and select everything that is divisible by 2
			var uniqueValues = newNumbers.Select(numbers => numbers * 2)
										 .Distinct()
										 .Where(x => x % 2 == 0);
										 

			foreach (var item in uniqueValues)
			{
				Console.WriteLine(item);
			}
		}
	}
}
