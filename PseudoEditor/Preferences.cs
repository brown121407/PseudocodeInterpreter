using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PseudoEditor
{
	class Preferences
	{
		private const string PrefsFilePath = "Preferences.json";

		private string _lastFile = null;
		private string _fontName = "Consolas";
		private int _fontSize = 18;

		[JsonProperty]
		public string LastFile
		{
			get => _lastFile;
			set 
			{ 
				_lastFile = value;
				Save();
			}
		}

		[JsonProperty] public string FontName
		{
			get => _fontName;
			set
			{
				_fontName = value;
				Save();
			}
		}

		[JsonProperty] public int FontSize
		{
			get => _fontSize;
			set
			{
				_fontSize = value;
				Save();
			}
		}

		private void Save()
		{
			string json = JsonConvert.SerializeObject(this, Formatting.Indented);
			File.WriteAllText(PrefsFilePath, json);
		}

		public void Load()
		{
			if (!File.Exists(PrefsFilePath))
			{
				Save();
			}
			else
			{
				string fileContent = File.ReadAllText(PrefsFilePath);
				Preferences loadedPrefs = JsonConvert.DeserializeObject<Preferences>(fileContent);

				this.LastFile = loadedPrefs.LastFile;
				this.FontName = loadedPrefs.FontName;
				this.FontSize = loadedPrefs.FontSize;
			}
		}
	}
}
