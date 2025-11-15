using Lemure.DesignPatterns.Adapter.Concretes;
using Lemure.DesignPatterns.Adapter.Contracts;

namespace Lemure.DesignPatterns.Adapter;

	public class Adapter : ITarget
	{
		public readonly Adaptee _adaptee;

		public Adapter(Adaptee adaptee)
		{
			_adaptee = adaptee;
		}

		public string GetRequest()
		{
			return $"This is '{_adaptee.GetSpecificRequest()}'";
		}
	}
