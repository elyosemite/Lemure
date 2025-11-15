using System;
using lemure.interfaces;

namespace lemure.services;

	class OracleDatabaseService : IDatabase
	{
		public void delete()
		{
			Console.WriteLine("Oracle...");
			Console.WriteLine("Deleting 1 row");
		}

		public void insert()
		{
			Console.WriteLine("Oracle...");
			Console.WriteLine("Inserting 1 row");
		}

		public void select()
		{
			Console.WriteLine("Oracle...");
			Console.WriteLine("Selecting 1 row");
		}

		public void update()
		{
			Console.WriteLine("Oracle...");
			Console.WriteLine("Updating 1 row");
		}
	}
