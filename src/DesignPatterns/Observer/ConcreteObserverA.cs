using System;
using lemure.DesignPatterns.Observer.Contracts;

namespace lemure.DesignPatterns.Observer;

	public class ConcreteObserverA : IObserver
	{
		public bool msg { get; set; } = false;
		public void Update(ISubject subject)
		{
			Console.WriteLine($"It has reacted an event A - {this.msg} - {subject.name}");
		}
	}
