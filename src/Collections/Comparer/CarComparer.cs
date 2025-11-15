using System.Collections.Generic;
using Lemure.Collections.Comparable;

namespace Lemure.Collections.Comparer;

	public class CarComparer : IComparer<Car>
	{
		public enum SortBy
		{
			Name,
			MaxSpeed
		}
		private SortBy compareField = SortBy.Name;

		public int Compare(Car x, Car y)
		{
			switch (compareField)
			{
				case SortBy.Name:
					return x.Name.CompareTo(y.Name);
				case SortBy.MaxSpeed:
					return x.MaxSpeed.CompareTo(y.MaxSpeed);
				default:
					break;
			}
			return x.Name.CompareTo(y.Name);
		}
	}
