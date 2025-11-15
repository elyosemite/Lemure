using System;
using lemure.interfaces;

namespace lemure.services;

	class MySQLDatabaseService : IDatabase
	{
		public void delete()
		{
			Console.WriteLine("MySQL...");
			Console.WriteLine("Deleting 1 row");
		}

		public void insert()
		{
			Console.WriteLine("MySQL...");
			Console.WriteLine("Inserting 1 row");
		}

		public void select()
		{
			Console.WriteLine("MySQL...");
			Console.WriteLine("Selecting 1 row");
		}

		public void update()
		{
			Console.WriteLine("MySQL...");
			Console.WriteLine("Updating 1 row");
		}
	}
