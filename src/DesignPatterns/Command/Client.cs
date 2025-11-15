using Lemure.DesignPatterns.Command.Commands;
using Lemure.DesignPatterns.Command.Invokers;
using Lemure.DesignPatterns.Command.Receveirs;

namespace Lemure.DesignPatterns.Command;

	public class Client
	{
		public static void Run()
		{
			// Cómodo da Casa

			// Reveiver
			var bedroomLight = new SmartHouseReceiver("Bedroom Light");
			var bathroomLight = new SmartHouseReceiver("Bathroom Light");
			var bathroomLightIntensity = new SmartHouseReceiver("Bathroom Light Intensity");

			// Command
			var bedroomLightPowerCommand = new LightPowerCommand(bedroomLight);
			var bathroomLightPowerCommand = new LightPowerCommand(bathroomLight);

			var bathroomLightIntensityCommand = new LightIntensityCommand(bathroomLightIntensity);

			// Invoker
			var smartHouseInvoker = new SmartHouseInvoker();

			smartHouseInvoker.AddCommand("bedroom-light-power", bedroomLightPowerCommand);
			smartHouseInvoker.AddCommand("bathroom-light-power", bathroomLightPowerCommand);

			smartHouseInvoker.AddCommand("bathroom-light-intensity", bathroomLightIntensityCommand);

			smartHouseInvoker.ExecuteCommand("bedroom-light-power");
			smartHouseInvoker.UndoCommand("bedroom-light-power");

			smartHouseInvoker.ExecuteCommand("bathroom-light-power");
			smartHouseInvoker.UndoCommand("bathroom-light-power");

			smartHouseInvoker.ExecuteCommand("bathroom-light-intensity");
			smartHouseInvoker.UndoCommand("bathroom-light-intensity");
		}
	}
