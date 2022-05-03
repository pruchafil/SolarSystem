using System;

namespace SolarSystem.SaveSystem {
	internal static class FilePath {
		public static readonly string
			planets = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "planets.json"),
			others = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "others.json"),
			satellites = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "satellites.json"),
			smallplanets = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "smallplanets.json");
	}
}