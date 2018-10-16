using Class07Demo.Classes;
using System;
// Don't forget this!!!
using System.Collections.Generic;

namespace Class07Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			Panda panda = new Panda();
			Days sunday = Days.Monday;
			Days thurs = Days.Thursday;

			//Console.WriteLine((int)sunday);
			//Console.WriteLine((int)thurs);

			//GenericExample();
			LibraryExample();

		}

		// a generic collection contains a group of things that are of the same type
		static void GenericExample()
		{
			// arrays need a size 
			string[] myArray = new string[5];
			// lists do not need a size
			List<string> myCats = new List<string>();

			myCats.Add("Josie");
			myCats.Add("Belle");
			myCats.Add("Matilda");
			myCats.Add("Flash");
			myCats.Add("Kimchi");
			myCats.Add("Kimchi");
			myCats.Add("Kimchi");


			// awesomesauce; foreach is powerful
			foreach (string cat in myCats)
			{
				Console.WriteLine(cat);
			}
			// Remove() and Clear() are methods on the List collection
			//myCats.RemoveAll("Kimchi");
			myCats.Clear();
			
			Console.WriteLine("=============");
			foreach (string cat in myCats)
			{
				Console.WriteLine(cat);
			}

			var ll = new LinkedList<string>();

			//Dictionary<, string> dictionary = new Dictionary<int, string>();

			//Queue<Node>
		}

		static void LibraryExample()
		{
			Book book = new Book();
			book.Title = "Where the Wild Things Are";
			book.NumberOfPages = 40;
			// instantiate a new Author
			book.Author = new Author { FirstName = "Maurice", LastName = "Sendak" };
			// choose a Genre from our enum
			book.Genre = Genre.Fiction;

			// instantiate a new Library
			// you can use a collection initializer if you have an add method called Add() *and* you implement IEnumerable
			Library<Book> myLibrary = new Library<Book>()
			{
				new Book { Title = "Book1", Genre = Genre.Fiction },
				new Book { Title = "Book1", Genre = Genre.Fiction },
				new Book { Title = "Book1", Genre = Genre.Fiction },

			};


			myLibrary.Add(book);
			myLibrary.Add(book);
			myLibrary.Add(book);
			myLibrary.Add(book);
			myLibrary.Add(book);
			myLibrary.Add(book);

			foreach (Book item in myLibrary)
			{
				Console.WriteLine(item.Title);
			}

		}
	}
}
