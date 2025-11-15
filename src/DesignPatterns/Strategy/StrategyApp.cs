using Lemure.DesignPatterns.Strategy.Concretes;
using Lemure.DesignPatterns.Strategy.Contracts;

namespace Lemure.DesignPatterns.Strategy;

	public class StrategyApp
	{
		public static void Run()
		{
			IRouteStrategy roadStrategy = new RoadStrategy();
			IRouteStrategy walkingStrategy = new WalkingStrategy();
			IRouteStrategy publicTransportStrategy = new PublicTransportStrategy();


			NavigatorContext navigatorContext = new NavigatorContext();


			navigatorContext.SetStrategy(roadStrategy);
			navigatorContext.ExecuteStrategy(1, 2);

			navigatorContext.SetStrategy(walkingStrategy);
			navigatorContext.ExecuteStrategy(3, 5);

		}
	}
