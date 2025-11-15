using System;
using Lemure.DesignPatterns.FactoryMethod.Concretes;
using Lemure.DesignPatterns.FactoryMethod.Contracts;

namespace Lemure.DesignPatterns.FactoryMethod.Creators;

	public class LinuxDialogFactory : Dialog
	{
		public override Button FactoryMethod()
		{
			Console.WriteLine("Create Button for Linux...");
			return new LinuxButton();
		}
	}
