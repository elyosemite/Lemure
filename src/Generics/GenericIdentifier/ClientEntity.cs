using System;

namespace Lemure.Generics.GenericIdentifier;

	internal class ClientEntity : IGeneric<int>
	{
		public void ProcessEntity(int id)
		{
			// call 3rd party API with int Id
			Console.WriteLine(id);
		}
	}
