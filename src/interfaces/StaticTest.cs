using System;

namespace lemure.interfaces;

	public static class StaticTest
	{
		private static int firstNumber { get; set; }
		private static int secondNumber { get; set; }
		private static int result { get; set; }
		public static void sum(int firstN, int secondN)
		{
			firstNumber = firstN;
			secondNumber = secondN;
			result = firstN + secondN;
		}
		public static void GetResult()
		{
			Console.WriteLine($"FirstN: {firstNumber}");
			Console.WriteLine($"FirstN: {secondNumber}");
			Console.WriteLine($"FirstN: {result}\n\n");
		}

		public static int GetNumber1()
		{
			return firstNumber;
		}

		public static int GetNumber2()
		{
			return secondNumber;
		}

		public static int GetRes()
		{
			return result;
		}
	}
