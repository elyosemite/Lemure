using MediatR;

namespace Lemure.DesignPatterns.CQRS.Commands;

	public class ExcluirPessoaCommand : IRequest<string>
	{
		public int Id { get; set; }
	}
