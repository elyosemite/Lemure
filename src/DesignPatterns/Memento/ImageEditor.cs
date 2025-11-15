using System;
using Lemure.DesignPatterns.Memento.Concretes;
using Lemure.DesignPatterns.Memento.Contracts;

namespace Lemure.DesignPatterns.Memento;

	public class ImageEditor
	{
		private string FilePath;
		private string FileFormat;

		public void ConvertFormatTo(string format)
		{
			FileFormat = format;
			FilePath = FilePath.Split('.')[0] + '.' + format;
		}

		public IMemento Save()
		{
			DateTime datetime = DateTime.Now;
			return ConcreteMemento.Create("Photoshop", datetime, FilePath, FileFormat);
		}

		public void Restore(IMemento memento)
		{
			ConcreteMemento concreteMemento = memento as ConcreteMemento;
			FileFormat = concreteMemento.GetFileFormat();
			FilePath = concreteMemento.GetFilePath();
		}
	}
