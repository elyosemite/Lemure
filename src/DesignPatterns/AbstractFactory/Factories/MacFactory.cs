using Lemure.DesignPatterns.AbstractFactory.Concretes;
using Lemure.DesignPatterns.AbstractFactory.Contracts;

namespace Lemure.DesignPatterns.AbstractFactory.Factories;

	public class MacFactory : GUIFactory
	{
		public Button ButtonFactory()
		{
			return new MacButton();
		}

		public Checkbox CheckboxFactory()
		{
			return new MacCheckbox();
		}
	}
