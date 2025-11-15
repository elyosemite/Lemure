namespace Lemure.DesignPatterns.Command.Contracts;

	public interface ISmartHouse
	{
		void Execute();
		void Undo();
	}
