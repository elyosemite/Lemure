using MediatR;

namespace Lemure.DesignPatterns.CQRS.Commands;

	public class CadastraPessoaCommand : IRequest<string>
	{
		public string Nome { get; set; }
		public int Idade { get; set; }
		public char Sexo { get; set; }
	}
