namespace Lemure.DesignPatterns.Strategy.Contracts;

	public interface IRouteStrategy
	{
		void BuildRoute(int coordinateX, int coordinateY);
	}
