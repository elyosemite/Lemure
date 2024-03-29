using System;
using System.Threading;
using System.Threading.Tasks;
using Lemure.DesignPatterns.CQRS.Notifications;
using MediatR;

namespace Lemure.DesignPatterns.CQRS
{
	public class EventLogHandler :
							INotificationHandler<PessoaCriadaNotification>,
							INotificationHandler<PessoaAlteradaNotification>,
							INotificationHandler<PessoaExcluidaNotification>,
							INotificationHandler<ErroNotification>
	{
		public Task Handle(PessoaCriadaNotification notification, CancellationToken cancellationToken)
		{
			return Task.Run(() =>
			{
				Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Nome} - {notification.Idade} - {notification.Sexo}'");
			});
		}

		public Task Handle(PessoaAlteradaNotification notification, CancellationToken cancellationToken)
		{
			return Task.Run(() =>
			{
				Console.WriteLine($"ALTERACAO: '{notification.Id} - {notification.Nome} - {notification.Idade} - {notification.Sexo} - {notification.IsEfetivado}'");
			});
		}

		public Task Handle(PessoaExcluidaNotification notification, CancellationToken cancellationToken)
		{
			return Task.Run(() =>
			{
				Console.WriteLine($"EXCLUSAO: '{notification.Id} - {notification.IsEfetivado}'");
			});
		}

		public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
		{
			return Task.Run(() =>
			{
				Console.WriteLine($"ERRO: '{notification.Excecao} \n {notification.PilhaErro}'");
			});
		}
	}
}