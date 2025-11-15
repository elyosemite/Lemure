using System;
using lemure.helpers;
using lemure.interfaces;

namespace lemure.Controllers;

	class CustomerController
	{
		private readonly IDatabase _databaseConnect;

		public CustomerController(IDatabase databaseConnect)
		{
			this._databaseConnect = databaseConnect;
		}

		public static void message()
		{
			Console.WriteLine(sumNumber.Sum2Number(2, 2));
			Console.WriteLine("Testing...");
		}

		public IDatabase getRepository()
		{
			return this._databaseConnect;
		}

	}
