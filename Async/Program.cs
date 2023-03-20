// See https://aka.ms/new-console-template for more information
using Async;
//diagnostics
using System.Diagnostics;

//init cont
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

Console.WriteLine("WELCOME Sync");
CalculatorSync.GetYearsOfExperience();
Console.WriteLine(CalculatorSync.isLessThan10());
Console.WriteLine(CalculatorSync.isGreaterThan10());
Console.WriteLine("BYE...");
//end cont
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed); //00:00:11.016378


//Reset for Async
Stopwatch stopwatchAsync = new Stopwatch();
stopwatchAsync.Start();

Console.WriteLine("WELCOME Async");
Task<int> years = CalculatorAsync.GetYearsOfExperience();
Task<bool> lt = CalculatorAsync.isLessThan10();
Task<bool> gt = CalculatorAsync.isGreaterThan10();
//Console.WriteLine(await CalculatorAsync.isGreaterThan10());
while(!years.IsCompleted || !lt.IsCompleted || !gt.IsCompleted) {
	Console.Write("");
}
Console.WriteLine("BYE...");
//end cont
stopwatchAsync.Stop();
Console.WriteLine(stopwatchAsync.Elapsed); //00:00
