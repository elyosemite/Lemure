using Lemure.DesignPatterns.Specification.Specs;

namespace Lemure.DesignPatterns.Specification;

	public enum Color
	{
		Black,
		White,
		Silver,
		Yellow
	}

	public enum CarBody
	{
		Seda,
		Cupe,
		SUV,
		Conversivel
	}

	public class Car
	{
		public int ModelYear { get; private set; }
		public Color Color { get; private set; }
		public CarBody CarBody { get; private set; }

		public static Car CarFactory(int modelYear, Color color, CarBody carBody)
		{
			Car car = new Car();

			car.ModelYear = modelYear;
			car.Color = color;
			car.CarBody = carBody;

			return car;
		}

		public static bool Valid(Car car)
		{
			return new LuxuryCarSpecification().IsSatisfiedBy(car);
		}
	}
