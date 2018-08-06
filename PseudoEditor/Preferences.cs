using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PseudoEditor
{
	public class Preferences
	{
		private const string PrefsFilePath = "Preferences.json";

		private string _lastFile = null;
		private string _fontName = "Consolas";
		private int _fontSize = 18;
		private bool _openLastFile = false;

		public event Action OnFontNameChanged;
		public event Action OnFontSizeChanged;

		public Preferences()
		{
			OnFontNameChanged += Save;
			OnFontSizeChanged += Save;
		}

		[JsonIgnore]
		public HashSet<string> FontNames { get; } = new HashSet<string>
		{
			"Consolas", "Courier", "Courier New"
		};

		[JsonIgnore] public IEnumerable<int> FontSizes { get; } = Enumerable.Range(1, 50);

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
				OnFontNameChanged?.Invoke();
			}
		}

		[JsonProperty] public int FontSize
		{
			get => _fontSize;
			set
			{
				_fontSize = value;
				OnFontSizeChanged?.Invoke();
			}
		}

		[JsonProperty]
		public bool OpenLastFile
		{
			get => _openLastFile;
			set
			{
				_openLastFile = value;
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

				_fontName = loadedPrefs.FontName;
				_fontSize = loadedPrefs.FontSize;
				_openLastFile = loadedPrefs.OpenLastFile;

				if (!File.Exists(loadedPrefs.LastFile))
				{
					_lastFile = null;
				}
				else
				{
					_lastFile = loadedPrefs.LastFile;
				}
			}
		}
	}
}
