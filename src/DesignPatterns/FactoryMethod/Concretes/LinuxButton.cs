using System;
using Lemure.DesignPatterns.FactoryMethod.Contracts;

namespace Lemure.DesignPatterns.FactoryMethod.Concretes;

	public class LinuxButton : Button
	{
		public void Render()
		{
			Console.WriteLine("Rendering the Linux Button");
		}
	}
