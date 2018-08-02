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

		public MainWindow()
		{
			InitializeComponent();

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
				_currentFileName = dialog.FileName;
				Editor.Load(_currentFileName);
				ShowFileName();
				_isFileSaved = true;
			}
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
			}
		}

		private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			Close();
		}

		private void Editor_OnTextChanged(object sender, EventArgs e)
		{
			if (_currentFileName != null)
			{
				ShowFileNameChanged();
				_isFileSaved = true;
			}
		}

		private void ComboBoxFontName_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Editor.FontFamily = new FontFamily(ComboBoxFontName.SelectedItem.ToString());
		}

		private void ComboBoxFontSize_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Editor.FontSize = int.Parse(ComboBoxFontSize.SelectedItem.ToString());
		}

		private void ComboBoxFontSize_OnLoaded(object sender, RoutedEventArgs e)
		{
			ComboBoxFontSize.ItemsSource = Enumerable.Range(1, 100);
			ComboBoxFontSize.SelectedIndex = DefaultFontSizeIndex;
		}

		private void ComboBoxFontName_OnLoaded(object sender, RoutedEventArgs e)
		{
			List<string> fontNames = new List<string>
			{
				"Consolas",
				"Courier",
				"Courier New"
			};

			ComboBoxFontName.ItemsSource = fontNames;
			ComboBoxFontName.SelectedIndex = DefaultFontNameIndex;
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
	}
}
