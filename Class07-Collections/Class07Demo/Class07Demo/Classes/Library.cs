using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Class07Demo.Classes
{
	// T for type is the industry standard
	// IEnumerable means that the class Library can be enumerated through (looped through) with an enumerator 
	class Library<T> : IEnumerable
	{
		// no industry standard for size here
		// this is the minimum size allocation
		T[] books = new T[5];
		int count = 0;

		public void Add(T book)
		{
			if(count == books.Length)
			{
				// array methods are fine to use now (hurray!)
				// Resize() is not magic; it is an array under the hood, doing normal array things
				Array.Resize(ref books, books.Length * 2);
			}
			// count++ will only increase count *after* the action has been taken. ++count would do it before
			books[count++] = book;


		}

		public Library<T> ReturnBooks(string title)
		{

		}

		public IEnumerator<T> GetEnumerator()
		{
			// this is the underlying loop that will allow your foreach loop to run
			for (int i = 0; i < count; i++)
			{
				yield return books[i];
			}

		}

		// Magic don't touch.
		// this is required to allow enumeration with legacy code
		// this is not a generic, we are using it to call the version that is a generic (above)
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
