using System;
using System.Collections.Generic;
using System.Text;

namespace Class08Demo.Classes
{
	class Pogs
	{
		public Color Color { get; set; }
		public string Name { get; set; }


	}

	public enum Color
	{
		Red = 24,
		Purple = 54,
		Green = 90,
		Pink,
		Blue = Purple + 2
	}
}
