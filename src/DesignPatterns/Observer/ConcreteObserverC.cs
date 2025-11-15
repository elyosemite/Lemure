using System;
using lemure.DesignPatterns.Observer.Contracts;

namespace lemure.DesignPatterns.Observer;

	public class ConcreteObserverC : IObserver
	{
		public bool msg { get; set; } = false;

		public void Update(ISubject subject)
		{
			Console.WriteLine($"It has reacted an event C {this.msg}\n");
		}
	}
