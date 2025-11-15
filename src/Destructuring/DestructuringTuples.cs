using System;

namespace lemure.Destructuring;

	public class DestructuringTuples
	{
		private static (string, int, double) QueryCityData(string name)
		{
			if (name == "New York City")
				return (name, 8175133, 468.77);
			return ("", 0, 0);
		}

		public static (string, string, string, int) GetAddressInfo()
		{
			return (
				"Yuri Melo",
				"Batalha",
				"Alagoas",
				180
			);
		}

		public static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
		{
			int population1 = 0, population2 = 0;
			double area = 0;

			if (name == "New York City")
			{
				area = 468.48;
				if (year1 == 1960)
				{
					population1 = 7781984;
				}
				if (year2 == 2010)
				{
					population2 = 8175133;
				}
				return (name, area, year1, population1, year2, population2);
			}

			return ("", 0, 0, 0, 0, 0);
		}
		public static void GetData()
		{
			var result = QueryCityData("New York City");
			var city = result.Item1;
			var pop = result.Item2;
			var size = result.Item3;
			Console.WriteLine(city);
			Console.WriteLine(pop);
			Console.WriteLine(size);
		}
	}
