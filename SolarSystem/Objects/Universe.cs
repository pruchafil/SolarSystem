using System.Collections.Generic;
using System.Linq;

namespace SolarSystem.Objects {
	public class UniverseObject<T> {
		protected static List<T> _collection;
		protected static string _path;

		protected static void Init(string path) {
			_path = path;

			SaveSystem.JSONHandler.CreateIfDoesNotExist<T>(path);
			T[] l = SaveSystem.JSONHandler.GetObject<T[]>(path);
			_collection = new List<T>(l ?? System.Array.Empty<T>());
		}

		public static void AddItem(T item) {
			_collection.Add(item);
			SaveSystem.JSONHandler.WriteObject<T[]>(_path, _collection.ToArray());
		}

		public static void RemoveItem(T item) {
			_collection.Remove(item);
			SaveSystem.JSONHandler.WriteObject<T[]>(_path, _collection.ToArray());
		}

		public static T[] GetCollection() => _collection.ToArray();
	}

	public class Planet : UniverseObject<Planet> {
		public static void Init() => Init(SaveSystem.FilePath.planets);

		public string Name { get; set; }
		public double Radius { get; set; }
		public string About { get; set; }
	}

	public class SmallPlanet : UniverseObject<SmallPlanet> {
		public static void Init() => Init(SaveSystem.FilePath.smallplanets);

		public string Name { get; set; }
		public double Radius { get; set; }
		public string About { get; set; }
	}

	public class Satellite : UniverseObject<Satellite> {
		public static void Init() => Init(SaveSystem.FilePath.satellites);

		public string Name { get; set; }
		public string Creation { get; set; }
		public string About { get; set; }
	}

	public class Other : UniverseObject<Other> {
		public static void Init() => Init(SaveSystem.FilePath.others);

		public string Name { get; set; }
		public string About { get; set; }
	}
}