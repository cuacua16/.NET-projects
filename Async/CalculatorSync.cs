using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async {
	internal class CalculatorSync {

		public static int GetYearsOfExperience() {
			Console.WriteLine("Calc initialized...");
			Task.Delay(5000).Wait();
			int years = new Random().Next(1, 25);
			Console.WriteLine("Years of experience: {0}", years);
			return years;
		}



		public static bool isLessThan10() {
			Console.WriteLine("Verifying if it's less than 10...");

			Task.Delay(3000).Wait();
			int years = new Random().Next(1, 25);
			return years < 10;
		}

		public static bool isGreaterThan10() {
			Console.WriteLine("Verifying if it's greater than 10...");

			Task.Delay(3000).Wait();
			int years = new Random().Next(1, 25);
			return years > 10;
		}


	}
}
