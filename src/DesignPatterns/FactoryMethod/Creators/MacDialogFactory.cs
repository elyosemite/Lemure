using System;
using Lemure.DesignPatterns.FactoryMethod.Concretes;
using Lemure.DesignPatterns.FactoryMethod.Contracts;

namespace Lemure.DesignPatterns.FactoryMethod.Creators;

	public class MacDialogFactory : Dialog
	{
		public override Button FactoryMethod()
		{
			Console.WriteLine("Create Button for Mac OS...");
			return new MacButton();
		}
	}
