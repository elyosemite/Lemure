namespace lemure.SOLID.OCP.OCP.Solucao_Extension_Methods;

	public static class DebitoContaInvestimento
	{
		public static string DebitarContaInvestimento(this DebitoConta debitoConta)
		{
			// Lógica de negócio para debito em conta investimento
			return debitoConta.FormatarTransacao();
		}
	}
