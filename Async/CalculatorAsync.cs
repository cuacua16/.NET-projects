using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async {
	internal class CalculatorAsync {

		public static async Task<int> GetYearsOfExperience() {
			Console.WriteLine("Calc initialized...");
			await Task.Delay(5000);
			int years = new Random().Next(1, 25);
			Console.WriteLine("Years of experience: {0}", years);
			return years;
		}



		public static async Task<bool> isLessThan10() {
			Console.WriteLine("Verifying if it's less than 10...");
			await Task.Delay(3000);
			int years = new Random().Next(1, 25);
			return years < 10;
		}


		public static async Task<bool> isGreaterThan10() {
			Console.WriteLine("Verifying if it's greater than 10...");

			await Task.Delay(3000);
			int years = new Random().Next(1, 25);
			return years > 10;
		}
	}
}
