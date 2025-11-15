using System;
using Lemure.DesignPatterns.AbstractFactory.Contracts;

namespace Lemure.DesignPatterns.AbstractFactory.Concretes;

	public class WindowsButton : Button
	{
		public void Paint()
		{
			Console.WriteLine("Windows Button");
		}
	}
