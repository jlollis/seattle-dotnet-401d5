using Class07Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Class07Demo.Classes
{
	class Bear : Animal, IClimb
	{
		public new string Name { get; set; } = "Rebecca";
		public void Height()
		{
			throw new NotImplementedException();
		}

		public new void Sound()
		{
			Console.WriteLine("hello hello");
		}

	
	}
}
