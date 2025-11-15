using System;
using System.Threading;
using System.Threading.Tasks;
using Lemure.DesignPatterns.CQRS.Commands;
using Lemure.DesignPatterns.CQRS.Notifications;
using MediatR;

namespace Lemure.DesignPatterns.CQRS.Handlers;

	public class ExcluiPessoaCommandHandler : IRequestHandler<ExcluirPessoaCommand, string>
	{
		private readonly IMediator _mediator;
		public ExcluiPessoaCommandHandler(IMediator mediator)
		{
			this._mediator = mediator;
		}

		public async Task<string> Handle(ExcluirPessoaCommand request, CancellationToken cancellationToken)
		{
			try
			{
				Console.WriteLine("Excluído da base de dados");

				await _mediator.Publish(new PessoaExcluidaNotification { Id = request.Id, IsEfetivado = true });

				return await Task.FromResult("Pessoa excluída com sucesso");
			}
			catch (Exception ex)
			{
				await _mediator.Publish(new PessoaExcluidaNotification { Id = request.Id, IsEfetivado = false });
				await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
				return await Task.FromResult("Ocorreu um erro no momento da exclusão");
			}
		}
	}
