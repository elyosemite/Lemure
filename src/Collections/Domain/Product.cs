namespace lemure.Collections.Domain;

	public class Product
	{
		public string _name { get; set; }
		public string _code { get; }
		public string _description { get; set; }

		public Product(string name, string code, string description)
		{
			_name = name;
			_code = code;
			_description = description;
		}
		public override string ToString()
		{
			return $"Name: {_name} - Code: {_code} - Description: {_description}";
		}
	}
