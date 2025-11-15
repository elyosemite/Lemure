using System;
using Lemure.DesignPatterns.AbstractFactory.Contracts;

namespace Lemure.DesignPatterns.AbstractFactory.Concretes;

	public class MacCheckbox : Checkbox
	{
		public void Paint()
		{
			Console.WriteLine("Mac Checkbox");
		}
	}
