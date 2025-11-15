using System;

namespace Lemure.Generics.GenericIdentifier;

	internal class InvoiceEntity : IGeneric<string>
	{
		public void ProcessEntity(string id)
		{
			// call 3rd party API with string Id
			Console.WriteLine(id);
		}
	}
