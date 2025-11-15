using Lemure.DesignPatterns.FactoryMethod.Creators;
using Lemure.Enums;

namespace Lemure.DesignPatterns.FactoryMethod;

	public class FactoryMethodApp
	{
		public Dialog Dialog { get; private set; }
		private readonly OpeSys _operatingSystem;

		public FactoryMethodApp(OpeSys operatingSystem)
		{
			_operatingSystem = operatingSystem;
		}

		public void Initialize()
		{
			// Check what operating system we are using
			if (OpeSys.Windows == _operatingSystem)
			{
				Dialog = new WindowsDialogFactory();
			}

			if (OpeSys.Linux == _operatingSystem)
			{
				Dialog = new LinuxDialogFactory();
			}

			if (OpeSys.MacOS == _operatingSystem)
			{
				Dialog = new MacDialogFactory();
			}
		}

		public void Run()
		{
			Initialize();
			Dialog.Render();
		}
	}
