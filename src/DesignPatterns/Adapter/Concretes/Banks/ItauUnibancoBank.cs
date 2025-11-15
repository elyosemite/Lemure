using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lemure.DesignPatterns.Adapter.Concretes.Banks;


	public struct Transaction
	{
		public string Usuario { get; }
		public string Destinatario { get; }
		public string Tipo { get; }
		public decimal Valor { get; }
		public string Data { get; }
		public string Status { get; }
		public string Banco { get; }

		[JsonConstructor]
		public Transaction(string usuario,
			string destinatario,
			string tipo,
			decimal valor,
			string data,
			string status,
			string banco)
		{
			Usuario = usuario;
			Destinatario = destinatario;
			Tipo = tipo;
			Valor = valor;
			Data = data;
			Status = status;
			Banco = banco;
		}
	}

	public class ItauUnibancoBank
	{
		public string GetTransaction()
		{
			Transaction transaction = new Transaction(
				"Yuri Melo",
				"Yrlan Teixeira",
				"PIX",
				10000,
				"01-09-2022",
				"sucesso",
				"Itaú Unibanco"
			);

			var result = JsonSerializer.Serialize(transaction);

			return result;
		}
	}
