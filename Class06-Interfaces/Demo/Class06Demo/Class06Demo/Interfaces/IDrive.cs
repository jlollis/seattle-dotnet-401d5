using System;
using System.Collections.Generic;
using System.Text;

namespace Class06Demo.Interfaces
{
  // these are the requirements that the class must meet
  // in order to use this interface
	interface IDrive
	{
		// property
		string DriversLicense { get; set; }
		// method
		void InsuranceCompany();

		string StartCar();
		string BrakeCar();

		
	}
}
