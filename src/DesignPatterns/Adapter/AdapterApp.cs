using System;
using Lemure.DesignPatterns.Adapter.Concretes;
using Lemure.DesignPatterns.Adapter.Contracts;

namespace Lemure.DesignPatterns.Adapter;

	public class AdapterApp
	{
		public static void Run()
		{
			Adaptee adaptee = new Adaptee();
			ITarget target = new Adapter(adaptee);

			Console.WriteLine("Adaptee interface is incompatible with the client.");
			Console.WriteLine("But with adapter client can call it's method.");

			Console.WriteLine(target.GetRequest());
		}
	}
