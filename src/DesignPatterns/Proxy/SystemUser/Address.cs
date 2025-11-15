namespace Lemure.DesignPatterns.Proxy.SystemUser;

	public struct Address
	{
		public string Street { get; }
		public int Number { get; }

		public Address(string street, int number)
		{
			Street = street;
			Number = number;
		}

		public override string ToString()
		{
			return $"Street: {Street} | Number {Number}";
		}
	}
