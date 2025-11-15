using System;

namespace lemure.interfaces;

	public class Use
	{
		public int number1 { get; set; }
		public int number2 { get; set; }
		public int res { get; set; }
		public void GetStatic()
		{
			Console.WriteLine("Estou dentro do Use class");
			StaticTest.GetResult();
		}

		public void GetInfo()
		{
			Console.WriteLine($"1. {number1}");
			Console.WriteLine($"2. {number2}");
			Console.WriteLine($"3. {res}");
		}
	}
