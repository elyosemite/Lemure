using System.Text.Json;
using Lemure.DesignPatterns.Adapter.Concretes.Banks;
using Lemure.DesignPatterns.Adapter.Contracts;

namespace Lemure.DesignPatterns.Adapter;

	public class BankAdapter : IFinantialTransaction
	{
		private readonly ItauUnibancoBank _itauUnibancoBank;

		public BankAdapter(ItauUnibancoBank itauUnibancoBank)
		{
			_itauUnibancoBank = itauUnibancoBank;
		}

		public string GetStatus()
		{
			var result = _itauUnibancoBank.GetTransaction();

			var obj = JsonSerializer.Deserialize<Transaction>(result);

			return obj.Status;
		}
	}
