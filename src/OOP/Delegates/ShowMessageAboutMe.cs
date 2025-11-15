using System;

namespace lemure.OOP.Delegates;

	public interface IEngineer
	{
		string _firstName { get; set; }
		string _lastName { get; set; }
		int _age { get; set; }
		string _position { get; set; }
	}

	public sealed class Engineer : IEngineer
	{
		public string _firstName { get; set; }
		public string _lastName { get; set; }
		public int _age { get; set; }
		public string _position { get; set; }

		public Engineer(string firstName, string lastName, int age, string position)
		{
			_firstName = firstName;
			_lastName = lastName;
			_age = age;
			_position = position;
		}
	}

	public class ShowMessageAboutMe
	{
		private delegate void InformationAboutEngineer(IEngineer engineer);

		public void ShowDelegate(IEngineer engineer)
		{
			InformationAboutEngineer yuri = new InformationAboutEngineer(InfoAboutPosition);
			yuri(engineer);
		}

		private void InfoAboutPosition(IEngineer engineer)
		{
			Console.WriteLine("My position: {0}", engineer._position);
		}
	}
