using Lemure.DesignPatterns.AbstractFactory.Contracts;

namespace Lemure.DesignPatterns.AbstractFactory;

	public interface GUIFactory
	{
		Button ButtonFactory();
		Checkbox CheckboxFactory();
	}
