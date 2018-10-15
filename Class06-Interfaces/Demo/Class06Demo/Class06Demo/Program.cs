using Class06Demo.Classes;
using Class06Demo.Interfaces;
using System;

namespace Class06Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			// Inheritance: what a class has
			// Interface: what a class can do

			// Limit the number of signatures in your interfaces!
			// 3-4, 5 if you absolutely must
			
		}

		static void InterfaceExample()
		{
			Clown bozo = new Clown();

			Android mrBot = new Android();

			// can mrBot drive? (does the Android class implement IDrive?)
			if (mrBot is IDrive)
			{
				string license = mrBot.DriversLicense;
			}

			R2d2 r2 = new R2d2();

			Car myCar = new Car();
			//R2 does not implement IDRive, therefore, it cannot drive myCar. Only Bozo or mrBot can.
			// myCar.Drive(r2) // will give an error
			myCar.Drive(bozo);
		}
	}
}
