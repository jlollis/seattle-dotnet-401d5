using System;
using System.Collections.Generic;

namespace DelegatesExample
{
	class Program
	{
		public delegate int MathDelegate(int a, int b);
		

		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			MathDelegate mathOperation = Add;
			Func<int, int, int> mathOp = Add;

			int a = 5;
			int b = 7;
			int result = mathOperation(a, b);
		}

		public static int Add(int a, int b)
		{
			return a + b;
		}

		public static int Subtract(int a, int b)
		{
			return a - b;
		}

		public static int Power(int baseNumber, int exponent)
		{
			return (int)Math.Pow(baseNumber, exponent);
		}

		public static List<int> OnlyEvens(List<int> numbers)
		{
			List<int> newNums = new List<int>();

			foreach (int number in numbers)
			{
				if(number% 2 ==0)
				{
					newNums.Add(number);
				}
			}

			return newNums;
		}
	}
}
