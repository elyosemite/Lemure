using System;

namespace Lemure.Collections.Comparable;

	public class Car : IComparable<Car>
	{
		public string Name { get; set; }
		public int MaxSpeed { get; set; }

		public int CompareTo(Car car)
		{
			if (car is not Car)
			{
				throw new ArgumentException("Object Is not Car");
			}
			if (MaxSpeed == car.MaxSpeed)
			{
				return Name.CompareTo(car.Name);
			}
			return car.MaxSpeed.CompareTo(MaxSpeed);
		}
		public override string ToString()
		{
			return MaxSpeed.ToString() + "," + Name;
		}
	}
