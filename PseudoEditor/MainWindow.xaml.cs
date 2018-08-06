using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Microsoft.Win32;
using Path = System.IO.Path;

namespace PseudoEditor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string _currentFileName;
		private const string WindowTitle = "PseudoEditor";
		private const string HighlightingFile = "PseudoHighlight.xshd";

		private bool _isFileSaved = false;

		private const string InterpreterName = "PseudocodeInterpreter.exe";

		private AboutWindow _aboutWindow = null;
		private ManualWindow _manualWindow = null;
		private PreferencesWindow _preferencesWindow = null;

		private readonly Preferences _preferences;

		public MainWindow()
		{
			InitializeComponent();

			_preferences = new Preferences();
			_preferences.Load();

			if (_preferences.OpenLastFile && _preferences.LastFile != null)
			{
				OpenFile(_preferences.LastFile);
			}

			_preferences.OnFontNameChanged += () => { Editor.FontFamily = new FontFamily(_preferences.FontName); };
			_preferences.OnFontSizeChanged += () => { Editor.FontSize = _preferences.FontSize; };

			ShowLineColumn();
			Editor.TextArea.Caret.PositionChanged += (sender, args) => ShowLineColumn();

			Editor.SyntaxHighlighting =
				HighlightingLoader.Load(XmlReader.Create(HighlightingFile), HighlightingManager.Instance);

			Editor.Focus();
		}


		private void ShowLineColumn()
		{
			LabelLines.Content = Editor.TextArea.Caret.Line;
			LabelColumns.Content = Editor.TextArea.Caret.Column;
		}

		private void ShowFileName()
		{
			LabelFilename.Content = _currentFileName;
			Title = $"{WindowTitle} - {_currentFileName}";
		}

		private void ShowFileNameChanged()
		{
			LabelFilename.Content = $"{_currentFileName}*";
			Title = $"{WindowTitle} - {_currentFileName}*";
		}

		private void New_OnExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			_currentFileName = null;
			var saveFileDialog = new SaveFileDialog
			{
				CheckPathExists = true,
				DefaultExt = "pseudo",
				FileName = "NewFile",
				OverwritePrompt = true,
				Filter = "Pseudocode file (*.pseudo)|*.pseudo|Text file (*.txt)|*.txt|All files (*.*)|*.*"
			};

			if (saveFileDialog.ShowDialog() == true)
			{
				_currentFileName = saveFileDialog.FileName;
				File.Create(_currentFileName).Close();
				Editor.Load(_currentFileName);
				ShowFileName();
				_isFileSaved = true;

				_preferences.LastFile = _currentFileName;
			}
		}

		private void Open_OnExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			var dialog = new OpenFileDialog {
				CheckFileExists = true,
				Filter = "Pseudocode file (*.pseudo)|*.pseudo|Text file (*.txt)|*.txt|All files (*.*)|*.*"
			};

			if (dialog.ShowDialog() == true)
			{
				OpenFile(dialog.FileName);
			}
		}

		private void OpenFile(string fileName)
		{
			_currentFileName = fileName;
			Editor.Load(_currentFileName);
			ShowFileName();
			_isFileSaved = true;

			_preferences.LastFile = _currentFileName;
		}

		private void Save_OnExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			SaveFile();
		}

		private void SaveAs_OnExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			SaveFileAs();
		}

		private void SaveFile()
		{
			if (_currentFileName == null)
			{
				SaveFileAs();
			}
			else
			{
				Editor.Save(_currentFileName);

				ShowFileName();
				_isFileSaved = true;

				_preferences.LastFile = _currentFileName;
			}
		}

		private void SaveFileAs()
		{
			var dialog = new SaveFileDialog
			{
				FileName = (_currentFileName == null ? "NewFile" : Path.GetFileName(_currentFileName)),
				DefaultExt = "pseudo",
				OverwritePrompt = true,
				CheckPathExists = true,
				Filter = "Pseudocode file (*.pseudo)|*.pseudo|Text file (*.txt)|*.txt|All files (*.*)|*.*"
			};

			if (dialog.ShowDialog() == true)
			{
				_currentFileName = dialog.FileName;
				Editor.Save(_currentFileName);
				ShowFileName();
				_isFileSaved = true;

				_preferences.LastFile = _currentFileName;
			}
		}

		private void Close_OnExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			CloseOtherWindows();
			Close();
		}

		private void CloseOtherWindows()
		{
			_aboutWindow?.Close();
			_manualWindow?.Close();
			_preferencesWindow?.Close();
		}

		private void Editor_OnTextChanged(object sender, EventArgs e)
		{
			if (_currentFileName != null)
			{
				ShowFileNameChanged();
				_isFileSaved = true;
			}
		}

		private void Execute_OnExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			SaveFile();

			if (_isFileSaved)
			{
				Process.Start(InterpreterName, $"{_currentFileName} diagnostics");
			}
		}

		private void About_OnExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (_aboutWindow == null)
			{
				_aboutWindow = new AboutWindow();
				_aboutWindow.Closed += (o, args) => { _aboutWindow = null; };
				_aboutWindow.Show();
			}
			else
			{
				_aboutWindow.Focus();
			}
		}

		private void MainWindow_Closed(object sender, EventArgs e)
		{
			CloseOtherWindows();
		}

		private void Preferences_OnExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (_preferencesWindow == null)
			{
				_preferencesWindow = new PreferencesWindow(_preferences);
				_preferencesWindow.Closed += (o, args) => { _preferencesWindow = null; };
				_preferencesWindow.Show();
			}
			else
			{
				_preferencesWindow.Focus();
			}
		}

		private void Help_OnExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (_manualWindow == null)
			{
				_manualWindow = new ManualWindow();
				_manualWindow.Closed += (o, args) => { _manualWindow = null; };
				_manualWindow.Show();
			}
			else
			{
				_manualWindow.Focus();
			}
		}

		private void Editor_OnLoaded(object sender, RoutedEventArgs e)
		{
			Editor.FontSize = _preferences.FontSize;
			Editor.FontFamily = new FontFamily(_preferences.FontName);
		}
	}
}
