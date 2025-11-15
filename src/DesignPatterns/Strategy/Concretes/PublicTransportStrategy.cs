using System;
using Lemure.DesignPatterns.Strategy.Contracts;

namespace Lemure.DesignPatterns.Strategy.Concretes;

	public class PublicTransportStrategy : IRouteStrategy
	{
		public void BuildRoute(int coordinateX, int coordinateY)
		{
			Console.WriteLine($"Calculating routing for Public Transport by using coordinates {coordinateX}  and {coordinateY}");
		}
	}
