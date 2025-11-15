using System;
using System.Runtime.Serialization;

namespace lemure.Serializable;

	public class Object1 : ISerializable
	{
		public readonly int _Id;
		public readonly string _Name;
		public readonly string _Code;

		public Object1(string Name, string code)
		{
			_Id = 123;
			_Name = Name;
			_Code = code;
		}

		public int Id
		{
			get { return _Id; }
		}

		public string Name
		{
			get { return _Name; }
		}

		public string Code
		{
			get { return _Code; }
		}

		protected Object1(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}

			_Id = info.GetInt32("Identifier");
			_Name = info.GetString("Name");
			_Code = info.GetString("Code");
		}
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Identifier", _Id);
			info.AddValue("Name", _Name);
			info.AddValue("Code", _Code);
		}
	}