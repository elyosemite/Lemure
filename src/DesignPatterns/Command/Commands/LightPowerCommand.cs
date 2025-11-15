using Lemure.DesignPatterns.Command.Contracts;
using Lemure.DesignPatterns.Command.Receveirs;

namespace Lemure.DesignPatterns.Command.Commands;

	public class LightPowerCommand : ISmartHouse
	{
		private readonly SmartHouseReceiver _smartHouseLight;

		public LightPowerCommand(SmartHouseReceiver smartHouseLight)
		{
			_smartHouseLight = smartHouseLight;
		}

		public void Execute()
		{
			_smartHouseLight.On();
		}

		public void Undo()
		{
			_smartHouseLight.Off();
		}
	}
