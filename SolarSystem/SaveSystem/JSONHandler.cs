using Newtonsoft.Json;

namespace SolarSystem.SaveSystem {
	public static class JSONHandler {
		public static void WriteObject<T>(string path, T obj) => System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(obj, Formatting.Indented));
		public static T GetObject<T>(string path) => JsonConvert.DeserializeObject<T>(System.IO.File.ReadAllText(path));
	}
}
