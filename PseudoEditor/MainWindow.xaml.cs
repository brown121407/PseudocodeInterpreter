using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
		private const string ProgramName = "PseudoEditor";

		public MainWindow()
		{
			InitializeComponent();

			Editor.Focus();

			ShowLineColumn();
			Editor.TextArea.Caret.PositionChanged += (sender, args) => ShowLineColumn();
		}

		private void ShowLineColumn()
		{
			LabelLines.Content = Editor.TextArea.Caret.Line;
			LabelColumns.Content = Editor.TextArea.Caret.Column;
		}

		private void ShowFileName()
		{
			LabelFilename.Content = _currentFileName;
			Title = $"{ProgramName} - {_currentFileName}";
		}

		private void ShowFileNameChanged()
		{
			LabelFilename.Content = $"{_currentFileName}*";
			Title = $"{ProgramName} - {_currentFileName}*";
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
			}
		}

		private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			if (_currentFileName == null)
			{
				SaveAs_Executed(sender, e);
			}
			else
			{
				Editor.Save(_currentFileName);
				ShowFileName();
			}
		}

		private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
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
			}
		}

		private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			this.Close();
		}

		private void Editor_OnTextChanged(object sender, EventArgs e)
		{
			if (_currentFileName != null)
			{
				ShowFileNameChanged();
			}
		}
	}
}
