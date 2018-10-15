using System;
using System.Collections.Generic;
using System.Text;

namespace Class06Demo.Classes
{
	abstract class Vehicle
	{
		public virtual int WheelNumber { get; set; } = 4;

		public string Engine { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
	}
}
