using System;
using Lemure.DesignPatterns.Strategy.Contracts;

namespace Lemure.DesignPatterns.Strategy.Concretes;

	public class RoadStrategy : IRouteStrategy
	{
		public void BuildRoute(int coordinateX, int coordinateY)
		{
			Console.WriteLine($"Calculating routing for Road by using coordinates {coordinateX}  and {coordinateY}");
		}
	}
