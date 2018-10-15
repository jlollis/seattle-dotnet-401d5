using System;
using System.Collections.Generic;
using System.Text;

namespace Class06Demo.Interfaces
{
	interface IDrivable
	{
		// no access modifiers here in the interface
		string Motor { get; set; }
		string Radio { get; set; }
		
		string Snacks { get; set; }

		string Drive(IDrive person);
	}
}
