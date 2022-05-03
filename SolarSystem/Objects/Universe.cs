using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SolarSystem.Objects {
	public class Universe<T> {
		protected static List<T> _collection;
		protected string _path;

		public void AddItem(T item) {
#pragma warning disable
			var l = SaveSystem.JSONHandler.GetObject<T[]>(_path).ToList();
#pragma warning restore
			l.Add(item);
			SaveSystem.JSONHandler.WriteObject<T[]>(_path, l.ToArray());

			_collection.Add(item);
		}

		public void RemoveItem(T item) {
#pragma warning disable
			var l = SaveSystem.JSONHandler.GetObject<T[]>(_path).ToList();
#pragma warning restore
			l.Remove(item);
			SaveSystem.JSONHandler.WriteObject<T[]>(_path, l.ToArray());

			_collection.Remove(item);
		}

		public static T[] GetCollection() => _collection.ToArray();
	}

	public class Planet : Universe<Planet> {
		static Planet() => _collection = new List<Planet>(SaveSystem.JSONHandler.GetObject<Planet[]>(SaveSystem.FilePath.planets));

		public string Name { get; set; }
		public double Radius { get; set; }
		public string About { get; set; }
	}

	public class SmallPlanet : Planet {
		static SmallPlanet() => _collection = new List<Planet>(SaveSystem.JSONHandler.GetObject<Planet[]>(SaveSystem.FilePath.smallplanets));
	}

	public class Satellite : Universe<Satellite> {
		static Satellite() => _collection = new System.Collections.Generic.List<Satellite>(SaveSystem.JSONHandler.GetObject<Satellite[]>(SaveSystem.FilePath.satellites));

		public string Name { get; set; }
		public string Creation { get; set; }
		public string About { get; set; }
	}

	public class Other : Universe<Other> {
		static Other() => _collection = new List<Other>(SaveSystem.JSONHandler.GetObject<Other[]>(SaveSystem.FilePath.smallplanets));

		public string Name { get; set; }
		public string About { get; set; }
	}
}