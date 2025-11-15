namespace Lemure.Generics.GenericIdentifier;

	internal interface IGeneric<TId>
	{
		void ProcessEntity(TId id);
	}
