using Class06Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Class06Demo.Classes
{
	class Car : Vehicle, IDrivable
	{
		public string Motor { get; set; }
		public string Radio { get; set; }
		public string Snacks { get; set; }

		public string Drive(IDrive person)
		{
			// starting a car is the responsibility of 
			// a Person, so that method is on the Person class
			person.StartCar();
			return "i drove";
		}
	}
}
