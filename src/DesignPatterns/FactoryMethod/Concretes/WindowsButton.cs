using System;
using Lemure.DesignPatterns.FactoryMethod.Contracts;

namespace Lemure.DesignPatterns.FactoryMethod.Concretes;

	public class WindowsButton : Button
	{
		public void Render()
		{
			Console.WriteLine("Rendering the Windows Button");
		}
	}
