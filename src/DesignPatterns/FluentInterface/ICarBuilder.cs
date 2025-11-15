namespace Lemure.DesignPatterns.FluentInterface;

	public interface ICarBuilder<out TEntity> where TEntity : class
	{
		TEntity SetCollor(string color);
		TEntity SetDoor(int amount = 4);
	}
