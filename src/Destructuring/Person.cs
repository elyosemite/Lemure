namespace lemure.Destructuring;

	public class Person
	{
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string City { get; set; }
		public string State { get; set; }

		public Person(string fname, string mname, string lname,
					  string cityName, string stateName)
		{
			FirstName = fname;
			MiddleName = mname;
			LastName = lname;
			City = cityName;
			State = stateName;
		}

		// Return the first and last name.
		public void Deconstruct(out string fname, out string lname)
		{
			fname = FirstName;
			lname = LastName;
		}

		public void Deconstruct(out string fname, out string mname, out string lname)
		{
			fname = FirstName;
			mname = MiddleName;
			lname = LastName;
		}

		public void Deconstruct(out string fname, out string lname,
								out string city, out string state)
		{
			fname = FirstName;
			lname = LastName;
			city = City;
			state = State;
		}
	}
