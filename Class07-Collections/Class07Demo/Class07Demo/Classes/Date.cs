using System;
using System.Collections.Generic;
using System.Text;

namespace Class07Demo.Classes
{
	class Date
	{
		// dates have a day of the week, we can use an enum for that property since the days of the week are set
		public Days DayOfWeek { get; set; }

		
	}

	// put your enums in the file that holds the class they are associated with
	// alternatively, you could have a class file that holds all your enums

	// set constants that allow a user (or you) to pick a value
	// by default, it's an int type (bytes are common, too)
	// starts at 0
	// if you set value of one, the remaining ones will follow in order

	// Days is a type
	enum Days
	{
		Monday,
		Tuesday,
		Wednesday = 18,
		Thursday,
		Friday = 21 ,
		Saturday = Friday + Thursday,
		Sunday = 19
	}
}
