using System;

namespace Lemure.DesignPatterns.Command.Receveirs;

	public class SmartHouseReceiver
	{
		public readonly string name;
		private bool IsOn { get; set; }
		private int Intensity { get; set; }

		public SmartHouseReceiver(string receiverName)
		{
			name = receiverName;
		}

		public string GetPowerStatus() => IsOn ? "On" : "Off";

		public bool On()
		{
			IsOn = true;
			Console.WriteLine($"The {name}' light is {GetPowerStatus()}");
			return IsOn;
		}

		public bool Off()
		{
			IsOn = false;
			Console.WriteLine($"The {name}' light is {GetPowerStatus()}");
			return IsOn;
		}

		public int IncreaseIntensity()
		{
			if (Intensity >= 100) return Intensity;
			Console.WriteLine($"The {nameof(Intensity)} is {Intensity}");
			Intensity += 1;
			return Intensity;
		}

		public int DecreaseIntensity()
		{
			if (Intensity <= 0) return Intensity;
			Intensity -= 1;
			return Intensity;
		}

	}
