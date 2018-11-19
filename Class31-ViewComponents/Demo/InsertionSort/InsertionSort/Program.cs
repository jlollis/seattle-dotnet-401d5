using System;

namespace InsertionSort
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		static void InsertionSort(int[] myArray)
		{

			//Algorithm:
			//* For loop for the outside to iterate through the list as a whole
			//* temp variable is going to hold the current value of index of array[i]
			//* Create a new counter (j) one position less than the index of our for loop to determine if temp is less than the position of j
			//* while j is equal to or greater than zero AND the value of temp is less than the position of j
			//* -  "move" the value of j over one position
			//* - "decrement" j back one position
			//* 
			//* once out of the while loop, we know 2 things are possible
			//*  - We are at the beginning of the list
			//*  - position of array[j] is less than temp, we know where our temp needs to be inserted, so we should insert the value
			//* increment our for loop one more index.


			for (int i = 1; i < myArray.Length; i++)
			{
				int temp = myArray[i];
				int j = i - 1;

				while (j >= 0 && temp < myArray[j])
				{
					myArray[j + 1] = myArray[j];
					j--;
				}

				myArray[j + 1] = temp;
			}

		
		}


	}
}
