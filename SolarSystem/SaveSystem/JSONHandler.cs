using Newtonsoft.Json;
using System;

namespace SolarSystem.SaveSystem {
	public static class JSONHandler {
		public static void CreateIfDoesNotExist<T>(string path) {
			if (!System.IO.File.Exists(path)) {
				System.IO.File.Create(path);
				WriteObject<T[]>(path, Array.Empty<T>());
			}
		}

		public static void WriteObject<T>(string path, T obj) => System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(obj, Formatting.Indented));
		public static T GetObject<T>(string path) => JsonConvert.DeserializeObject<T>(System.IO.File.ReadAllText(path));
	}
}