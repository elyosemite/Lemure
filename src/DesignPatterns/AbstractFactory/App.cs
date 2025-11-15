using System;
using Lemure.DesignPatterns.AbstractFactory.Factories;
using Lemure.Enums;

namespace Lemure.DesignPatterns.AbstractFactory;

	public class App
	{
		private GUIFactory _factory;
		private Application _app;

		public void Run(OpeSys operatingSystem)
		{
			#region Configuration
			if (operatingSystem == OpeSys.Windows)
			{
				_factory = new WindowsFactory();
			}
			else if (operatingSystem == OpeSys.MacOS)
			{
				_factory = new MacFactory();
			}
			else
			{
				Console.WriteLine("Operating System unknown");
				return;
			}
			#endregion

			_app = new Application(_factory);
			_app.CreateUI();
			_app.Paint();
		}

	}
