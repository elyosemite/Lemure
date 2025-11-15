using System;

namespace Lemure.Generics;

	public class Product : Identifier
	{
		private string _name { get; set; }
		private double _price { get; set; }

		public Product(string Name, double Price)
		{
			_name = Name;
			_price = Price;
			Id = Guid.NewGuid();
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is not Product)
			{
				throw new ArgumentException("Object must be Product");
			}
			var anotherPrice = obj as Product;
			return _price.Equals(anotherPrice._price);
		}

		public override string ToString()
		{
			return $"{Id} - Name: {_name} of Price equal to {_price}";
		}
	}
