namespace DesignPattern.Design_Patterns
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using Newtonsoft.Json.Linq;

	class Singleton
	{
		public static void HowToTest()
		{
			var user = Configuration.Settings["Username"];
			var server = Configuration.Settings["Server"];

			Console.WriteLine($"{server}, {user}");
		}
	}

	public sealed class Configuration
	{
		// Single instance Property
		public static Configuration Settings { get; } = new Configuration();

		// Configuration 객체가 갖는 데이터
		private Dictionary<string, object> dict = new Dictionary<string, object>();

		// Private 생성자
		private Configuration()
		{
			LoadConfig();
		}

		private void LoadConfig()
		{
			var str = File.ReadAllText("Config.json");
			JObject jo = JObject.Parse(str);

			foreach (var keyValue in jo)
			{
				dict.Add(keyValue.Key, keyValue.Value);
			}
		}

		// Key에 대한 Value를 return하는 indexer
		public object this[string key]
		{
			get
			{
				return dict[key];
			}
		}
	}
}
