using System;
using lemure.interfaces;

namespace lemure.services;

	class Db2DatabaseService : IDatabase
	{
		public void delete()
		{
			Console.WriteLine("DB2...");
			Console.WriteLine("Deleting 1 row");
		}

		public void insert()
		{
			Console.WriteLine("DB2...");
			Console.WriteLine("Inserting 1 row");
		}

		public void select()
		{
			Console.WriteLine("DB2...");
			Console.WriteLine("Selecting 1 row");
		}

		public void update()
		{
			Console.WriteLine("DB2...");
			Console.WriteLine("Updating 1 row");
		}
	}
