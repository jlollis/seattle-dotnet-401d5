using System;
using System.Collections.Generic;
using System.Text;

namespace Class07Demo.Classes
{
	class Book
	{
		// the Genre type is an enum
		public Genre Genre { get; set; }
		public string Title { get; set; }
		public int NumberOfPages { get; set; }
		// the Author type is a class
		public Author Author { get; set; }

	}

	enum Genre
	{
		SciFi,
		Mystery,
		Fiction,
		Romance
	}
}
