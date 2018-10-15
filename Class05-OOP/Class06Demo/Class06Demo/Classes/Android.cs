using System;
using System.Collections.Generic;
using System.Text;
using Class06Demo.Interfaces;

namespace Class06Demo.Classes
{
	class Android : Robot, IDrive
	{
		public string AI { get; set; }
		public string DriversLicense { get; set; }

		public void InsuranceCompany()
		{
			Console.WriteLine("Robots don't need insurance");
		}
	}
}
