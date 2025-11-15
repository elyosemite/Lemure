using System;

namespace lemure.SOLID.OCP.MyOwnCode;

	public abstract class DebitoConta
	{
		private int numeroDaTransacao { get; }
		public abstract string Debitar(decimal valor, string conta);
		public static string CodeGenerate()
		{
			return Guid.NewGuid().ToString();
		}
	}
