using System;
using System.Text;

namespace lemure.Reflection.WithReflection;

	public class LogWithReflection
	{
		public static void Log(object obj)
		{
			var type = obj.GetType();
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("Log of " + type.Name);
			builder.AppendLine("Date: " + DateTime.Now);

			foreach (var prop in type.GetProperties())
			{
				builder.AppendLine(prop.Name + ": " + prop.GetValue(obj));
			}
			LogPrint(builder.ToString());
		}

		public static void LogPrint(string texto)
		{
			Console.WriteLine(texto);
		}
	}
