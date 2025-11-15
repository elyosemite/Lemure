using Lemure.DesignPatterns.FactoryMethod.Contracts;

namespace Lemure.DesignPatterns.FactoryMethod;

	public abstract class Dialog
	{
		public abstract Button FactoryMethod();

		public void Render()
		{
			var button = FactoryMethod();
			button.Render();
		}
	}
