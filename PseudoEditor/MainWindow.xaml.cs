using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using ICSharpCode.AvalonEdit.CodeCompletion;
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

		private const int DefaultFontSizeIndex = 17;
		private const int DefaultFontNameIndex = 0;

		private bool _isFileSaved = false;

		private const string InterpreterName = "PseudocodeInterpreter.exe";

		private AboutWindow _aboutWindow = null;
		private ManualWindow _manualWindow = null;

		private Preferences preferences;

		public MainWindow()
		{
			InitializeComponent();

			preferences = new Preferences();
			preferences.Load();

			if (preferences.LastFile != null)
			{
				OpenFile(preferences.LastFile);
			}

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

		private void New_Executed(object sender, ExecutedRoutedEventArgs e)
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

				preferences.LastFile = _currentFileName;
			}
		}

		private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
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

			preferences.LastFile = _currentFileName;
		}

		private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			SaveFile();
		}

		private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
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

				preferences.LastFile = _currentFileName;
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

				preferences.LastFile = _currentFileName;
			}
		}

		private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			CloseOtherWindows();
			Close();
		}

		private void CloseOtherWindows()
		{
			_aboutWindow?.Close();
			_manualWindow?.Close();
		}

		private void Editor_TextChanged(object sender, EventArgs e)
		{
			if (_currentFileName != null)
			{
				ShowFileNameChanged();
				_isFileSaved = true;
			}
		}

		private void ComboBoxFontName_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var fontName = ComboBoxFontName.SelectedItem.ToString();
			Editor.FontFamily = new FontFamily(fontName);
			preferences.FontName = fontName;
		}

		private void ComboBoxFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var fontSize = int.Parse(ComboBoxFontSize.SelectedItem.ToString());
			Editor.FontSize = fontSize;
			preferences.FontSize = fontSize;
		}

		private void ComboBoxFontSize_Loaded(object sender, RoutedEventArgs e)
		{
			ComboBoxFontSize.ItemsSource = Enumerable.Range(1, 100);
			ComboBoxFontSize.SelectedIndex = preferences.FontSize - 1;
		}

		private void ComboBoxFontName_Loaded(object sender, RoutedEventArgs e)
		{
			List<string> fontNames = new List<string>
			{
				"Consolas",
				"Courier",
				"Courier New"
			};

			ComboBoxFontName.ItemsSource = fontNames;
			ComboBoxFontName.SelectedItem = preferences.FontName;
		}

		private void Execute_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			SaveFile();

			if (_isFileSaved)
			{
				Process.Start(InterpreterName, $"{_currentFileName} diagnostics");
			}
		}

		private void About_Executed(object sender, ExecutedRoutedEventArgs e)
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
	}
}
