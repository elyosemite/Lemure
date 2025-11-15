using System;
using Lemure.DesignPatterns.AbstractFactory.Contracts;

namespace Lemure.DesignPatterns.AbstractFactory.Concretes;

	public class WindowsCheckbox : Checkbox
	{
		public void Paint()
		{
			Console.WriteLine("Windows Checkbox");
		}
	}
