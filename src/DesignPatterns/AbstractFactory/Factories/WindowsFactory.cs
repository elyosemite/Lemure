using Lemure.DesignPatterns.AbstractFactory.Concretes;
using Lemure.DesignPatterns.AbstractFactory.Contracts;

namespace Lemure.DesignPatterns.AbstractFactory.Factories;

	public class WindowsFactory : GUIFactory
	{
		public Button ButtonFactory()
		{
			return new WindowsButton();
		}

		public Checkbox CheckboxFactory()
		{
			return new WindowsCheckbox();
		}
	}
