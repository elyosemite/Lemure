using System;
using Lemure.DesignPatterns.AbstractFactory.Contracts;

namespace Lemure.DesignPatterns.AbstractFactory.Concretes;

	public class MacButton : Button
	{
		public void Paint()
		{
			Console.WriteLine("MAC Button");
		}
	}
