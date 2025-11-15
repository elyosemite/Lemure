using System;
using System.Threading;
using System.Threading.Tasks;
using Lemure.DesignPatterns.CQRS.Commands;
using Lemure.DesignPatterns.CQRS.Models;
using Lemure.DesignPatterns.CQRS.Notifications;
using MediatR;

namespace Lemure.DesignPatterns.CQRS.Handlers;

	public class AlteraPessoaCommandHandler : IRequestHandler<AlterarPessoaCommand, string>
	{
		private readonly IMediator _mediator;

		public AlteraPessoaCommandHandler(IMediator mediator)
		{
			this._mediator = mediator;
		}

		public async Task<string> Handle(AlterarPessoaCommand request, CancellationToken cancellationToken)
		{
			var pessoa = new Pessoa { Id = request.Id, Nome = request.Nome, Idade = request.Idade, Sexo = request.Sexo };

			try
			{
				Console.WriteLine("Alterou na base de dados");

				await _mediator.Publish(new PessoaAlteradaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo, IsEfetivado = true });

				return await Task.FromResult("Pessoa alterada com sucesso");
			}
			catch (Exception ex)
			{
				await _mediator.Publish(new PessoaAlteradaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo, IsEfetivado = false });
				await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
				return await Task.FromResult("Ocorreu um erro no momento da alteração");
			}
		}
	}

