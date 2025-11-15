using System;
using System.Threading;
using System.Threading.Tasks;
using Lemure.DesignPatterns.CQRS.Commands;
using Lemure.DesignPatterns.CQRS.Models;
using Lemure.DesignPatterns.CQRS.Notifications;
using MediatR;

namespace Lemure.DesignPatterns.CQRS.Handlers;

	public class CadastraPessoaCommandHandler : IRequestHandler<CadastraPessoaCommand, string>
	{
		private readonly IMediator _mediator;

		public CadastraPessoaCommandHandler(IMediator mediator)
		{
			this._mediator = mediator;
		}

		public async Task<string> Handle(CadastraPessoaCommand request, CancellationToken cancellationToken)
		{
			var pessoa = new Pessoa { Nome = request.Nome, Idade = request.Idade, Sexo = request.Sexo };

			try
			{
				Console.WriteLine("Adicionada na base de dados");

				await _mediator.Publish(new PessoaCriadaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo });

				return await Task.FromResult("Pessoa criada com sucesso");
			}
			catch (Exception ex)
			{
				await _mediator.Publish(new PessoaCriadaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo });
				await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
				return await Task.FromResult("Ocorreu um erro no momento da criação");
			}
		}
	}