using System;
using lemure.interfaces;

namespace lemure.services;

	class PostegreSQLDatabaseService : IDatabase
	{
		public void delete()
		{
			Console.WriteLine("PostegreSQL...");
			Console.WriteLine("Deleting 1 row");
		}

		public void insert()
		{
			Console.WriteLine("PostegreSQL...");
			Console.WriteLine("Inserting 1 row");
		}

		public void select()
		{
			Console.WriteLine("PostegreSQL...");
			Console.WriteLine("Selecting 1 row");
		}

		public void update()
		{
			Console.WriteLine("PostegreSQL...");
			Console.WriteLine("Updating 1 row");
		}
	}
