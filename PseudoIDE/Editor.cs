using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;

namespace PseudoIDE
{
	public partial class Editor : Form
	{
		private const string ProgramName = "PseudoIDE";
		private const string NewFileName = "Untitled";
		private string _currentFileName = NewFileName;
		private bool _isFileSaved = false;
		private const string ProcessName = "PseudocodeInterpreter.exe";

		private int _maxLineNumberCharLength = 3;

		private HelpForm _helpForm = null;
		private OptionsForm _optionsForm = null;

		public Editor()
		{
			InitializeComponent();
		}

		private void Log(string msg)
		{
			logBox.WriteOutput(msg + Environment.NewLine, Color.White);
			ScrollOutputToBottom();
		}

		private void ScrollOutputToBottom()
		{
			logBox.InternalRichTextBox.SelectionStart = logBox.InternalRichTextBox.Text.Length;
			logBox.InternalRichTextBox.ScrollToCaret();
		}

		private Task SaveFile()
		{
			File.WriteAllText(_currentFileName, scintilla.Text);

			_isFileSaved = true;
			DisplayFileName();

			return Task.CompletedTask;
		}

		private Task SaveFileAs()
		{
			var result = saveFileDialog.ShowDialog();

			if (result == DialogResult.OK)
			{
				if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
				{
					File.WriteAllText(saveFileDialog.FileName, scintilla.Text);
					_currentFileName = saveFileDialog.FileName;
				}

				_isFileSaved = true;
				DisplayFileName();
			}

			return Task.CompletedTask;
		}

		private void DisplayFileName()
		{
			Text = $"{ProgramName} - {_currentFileName}";
			fileNameLabel.Text = _currentFileName;
		}

		private void DisplayFileName(string name)
		{
			_currentFileName = name;
			Text = $"{ProgramName} - {_currentFileName}";
			fileNameLabel.Text = name;
		}

		private void DisplayFileChanged()
		{
			Text = $"{ProgramName} - {_currentFileName}*";
			fileNameLabel.Text = _currentFileName + "*";
		}

		private void ScintillaSetup()
		{
			scintilla.TextChanged += scintilla_TextChanged;
			
			scintilla.SetSavePoint();
			scintilla.Select();

			scintilla.Styles[(int) SyntaxHighlighter.Styles.Default].ForeColor = DefaultForeColor;
			scintilla.Styles[(int) SyntaxHighlighter.Styles.Keyword].ForeColor = Color.Blue;
			scintilla.Styles[(int) SyntaxHighlighter.Styles.Identifier].ForeColor = Color.Teal;
			scintilla.Styles[(int) SyntaxHighlighter.Styles.Number].ForeColor = Color.Purple;
			scintilla.Styles[(int) SyntaxHighlighter.Styles.String].ForeColor = Color.Orange;

			scintilla.Margins[0].Width = 16;

			scintilla.AssignCmdKey(Keys.Control | Keys.S, Command.Null);
		}

		private void Editor_Load(object sender, EventArgs e)
		{
			ScintillaSetup();

			DisplayFileName();
		}

		private void scintilla_TextChanged(object sender, EventArgs e)
		{
			_isFileSaved = false;
			DisplayFileChanged();
		}

		private void newFileButton_Click(object sender, EventArgs e)
		{
			scintilla.Text = string.Empty;
			_currentFileName = NewFileName;
			_isFileSaved = false;
			DisplayFileName();
		}

		private void openFileButton_Click(object sender, EventArgs e)
		{
			var result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				try
				{
					string fileContent = File.ReadAllText(openFileDialog.FileName);
					scintilla.Text = fileContent;
					DisplayFileName(openFileDialog.FileName);
					_isFileSaved = true;
				}
				catch (Exception exception)
				{
					Log(exception.Message);
				}
			}
		}

		private async void saveFileButton_Click(object sender, EventArgs e)
		{
			if (_currentFileName == NewFileName)
			{
				await SaveFileAs();
			}
			else
			{
				await SaveFile();
			}
		}

		private async void saveFileAsButton_Click(object sender, EventArgs e)
		{
			await SaveFileAs();
		}

		private void toggleLoxBoxButton_Click(object sender, EventArgs e)
		{
			if (logBox.Visible)
			{
				logBox.Hide();
			}
			else
			{
				logBox.Show();
			}
		}

		private void clearLogButton_Click(object sender, EventArgs e)
		{
			logBox.ClearOutput();
		}

		private async void runButton_Click(object sender, EventArgs e)
		{
			if (!_isFileSaved)
			{
				if (_currentFileName.Equals(NewFileName))
				{
					await SaveFileAs();
				}
				else
				{
					await SaveFile();
				}
			}

			if (_isFileSaved)
			{
				var proc = Process.Start(ProcessName, $"{_currentFileName} diagnostics");
			}
		}

		private async void scintilla_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.S)
			{
				e.SuppressKeyPress = true;

				if (_currentFileName.Equals(NewFileName))
				{
					await SaveFileAs();
				}
				else
				{
					await SaveFile();
				}
			}
		}

		private void scintilla_StyleNeeded(object sender, ScintillaNET.StyleNeededEventArgs e)
		{
			var startPos = scintilla.GetEndStyled();
			var endPos = e.Position;

			SyntaxHighlighter.Style(scintilla, startPos, endPos);
		}

		private void scintilla_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar < 32)
			{
				// Prevent control characters from getting inserted into the text buffer
				e.Handled = true;
				return;
			}
		}

		private void scintilla_TextChanged_1(object sender, EventArgs e)
		{
			var maxLineNumberCharLength = scintilla.Lines.Count.ToString().Length;
			if (maxLineNumberCharLength == _maxLineNumberCharLength)
				return;

			// Calculate the width required to display the last line number
			// and include some padding for good measure.
			const int padding = 2;
			scintilla.Margins[0].Width = scintilla.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
			_maxLineNumberCharLength = maxLineNumberCharLength;
		}

		private void helpButton_Click(object sender, EventArgs e)
		{
			if (_helpForm == null)
			{
				_helpForm = new HelpForm();
				_helpForm.Closed += (o, args) => _helpForm = null; 
				_helpForm.Show();
			}
			else
			{
				_helpForm.Select();
			}
		}

		private void optionsButton_Click(object sender, EventArgs e)
		{
			if (_optionsForm == null)
			{
				_optionsForm = new OptionsForm();
				_optionsForm.Closed += (o, args) => _optionsForm = null;
				_optionsForm.Show();
			}
			else
			{
				_optionsForm.Select();
			}
		}
	}
}
