using MediatR;

namespace Lemure.DesignPatterns.CQRS.Commands;

	public class AlterarPessoaCommand : IRequest<string>
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int Idade { get; set; }
		public char Sexo { get; set; }
	}
