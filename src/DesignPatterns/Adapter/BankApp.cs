using System;
using Lemure.DesignPatterns.Adapter.Concretes.Banks;

namespace Lemure.DesignPatterns.Adapter;

	public class BankApp
	{
		public static void Run()
		{
			ItauUnibancoBank itauUnibancoBank = new ItauUnibancoBank();
			BankAdapter bankAdapter = new BankAdapter(itauUnibancoBank);

			Console.WriteLine(bankAdapter.GetStatus());
		}
	}
