using System;
using Lemure.DesignPatterns.Command.Contracts;
using Lemure.DesignPatterns.Command.Receveirs;

namespace Lemure.DesignPatterns.Command.Commands;

	public class LightIntensityCommand : ISmartHouse
	{
		private readonly SmartHouseReceiver _smartHouseReceiver;

		public LightIntensityCommand(SmartHouseReceiver smartHouseReceiver)
		{
			_smartHouseReceiver = smartHouseReceiver;
		}

		public void Execute()
		{
			var result = _smartHouseReceiver.IncreaseIntensity();
			Console.WriteLine($"Increase {_smartHouseReceiver.name}' Intensity to {result}");
		}

		public void Undo()
		{
			var result = _smartHouseReceiver.DecreaseIntensity();
			Console.WriteLine($"Decrease {_smartHouseReceiver.name}' Intensity to {result}");
		}
	}
