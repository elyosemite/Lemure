using Lemure.DesignPatterns.AbstractFactory.Contracts;

namespace Lemure.DesignPatterns.AbstractFactory;

	public class Application
	{
		private readonly GUIFactory _factory; //backing field
		private Button _button;

		public Application(GUIFactory factory)
		{
			_factory = factory;
		}

		public void CreateUI()
		{
			_button = _factory.ButtonFactory();
		}

		public void Paint()
		{
			_button.Paint();
		}
	}
