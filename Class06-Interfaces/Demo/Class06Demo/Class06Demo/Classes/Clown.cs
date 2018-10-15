using Class06Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Class06Demo.Classes
{
  // use this order: this (derived) class / base class / interface(s)
	class Clown: Person, IDrive
	{
		public bool IsScary { get; set; } = false;
		public string DriversLicense { get; set; }

		// access modifier can be used here in the class
		public void InsuranceCompany()
		{
			Console.WriteLine("My car is safe");
		}
	}
}
