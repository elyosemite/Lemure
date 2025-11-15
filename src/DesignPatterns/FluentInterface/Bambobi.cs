namespace Lemure.DesignPatterns.FluentInterface;

	public class Bambobi : ICarBuilder<Bambobi>
	{
		public string Collor { get; private set; }
		public int Door { get; private set; }

		public Bambobi SetCollor(string color)
		{
			if (string.IsNullOrEmpty(color))
			{
				Collor = string.Empty;
			}
			else
			{
				Collor = color;
			}

			return this;
		}

		public Bambobi SetDoor(int amount = 4)
		{
			Door = amount;
			return this;
		}

		public static Bambobi Create(string color, int amount)
		{
			Bambobi bambobi = new Bambobi();
			bambobi
				.SetCollor(color)
				.SetDoor(amount);

			return bambobi;
		}
	}
