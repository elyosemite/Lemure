using Lemure.DesignPatterns.Strategy.Contracts;

namespace Lemure.DesignPatterns.Strategy;

	public class NavigatorContext
	{
		private IRouteStrategy _routeStrategy;

		public void SetStrategy(IRouteStrategy routeStrategy)
		{
			_routeStrategy = routeStrategy;
		}

		public void ExecuteStrategy(int coordinateX, int coordinateY)
		{
			_routeStrategy.BuildRoute(coordinateX, coordinateY);
		}
	}
