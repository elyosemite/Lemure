using System;

namespace lemure.OOP;

	class CafeteiraExpressa : Eletrodomestico
	{

		public CafeteiraExpressa(string nome, int voltagem) : base(nome, voltagem)
		{

		}

		public CafeteiraExpressa() : base(nome: "padrão", voltagem: 220) { }

		private static void EsquentarAgua() { }
		private static void MoerGraos() { }

		public override void Testar()
		{
			//Testei meu equipamento...
		}

		public void PrepararCafe()
		{
			Testar();
			EsquentarAgua();
			MoerGraos();
		}

		public override void Desligar()
		{
			throw new NotImplementedException();
		}

		public override void Ligar()
		{
			throw new NotImplementedException();
		}
	}
