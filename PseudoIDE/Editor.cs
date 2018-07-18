using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PseudocodeInterpreter;
using ScintillaNET;

namespace PseudoIDE
{
	public partial class Editor : Form
	{
		private Scintilla _scintilla;
		private const string NewFileName = "Untitled";
		private string _currentFileName = NewFileName;

		public Editor()
		{
			InitializeComponent();
		}

		private void Editor_Load(object sender, EventArgs e)
		{
			_scintilla = new Scintilla
			{
				WrapMode = WrapMode.None,
				Dock = DockStyle.Fill,
				IndentationGuides = IndentView.LookBoth,
				Lexer = Lexer.Container,
			};

			_scintilla.TextChanged += scintilla_TextChanged;

			panelEditor.Controls.Add(_scintilla);

			_scintilla.Select();

			Interpreter.Output = Log;
			Interpreter.Input = () => "3";

			Log("Started IDE successfully.");
		}

		private void Log(string msg)
		{
			logBox.Text += msg + Environment.NewLine;
			ScrollToEndLogBox();
		}

		private void ShowProgramOutput(string output)
		{
			logBox.Text += output;
			ScrollToEndLogBox();
		}

		private void ScrollToEndLogBox()
		{
			logBox.SelectionStart = logBox.Text.Length;
			logBox.ScrollToCaret();
		}

		private void scintilla_TextChanged(object sender, EventArgs e)
		{
			if (_scintilla.Modified)
			{
				DisplayFileChanged();
			}
			else
			{
				DisplayFileName();
			}
		}

		private void newFileButton_Click(object sender, EventArgs e)
		{
			
		}

		private void openFileButton_Click(object sender, EventArgs e)
		{
			var result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				try
				{
					string fileContent = File.ReadAllText(openFileDialog.FileName);
					// TODO put it in the editor
				}
				catch (Exception exception)
				{
					// TODO log exception
				}
			}
		}

		private void saveFileButton_Click(object sender, EventArgs e)
		{
			
		}

		private void saveFileAsButton_Click(object sender, EventArgs e)
		{

		}

		private void exitButton_Click(object sender, EventArgs e)
		{

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
			logBox.Clear();
		}

		private void DisplayFileName()
		{
			Text = _currentFileName;
			fileNameLabel.Text = _currentFileName;
		}

		private void DisplayFileName(string name)
		{
			_currentFileName = name;
			this.Text = name;
			fileNameLabel.Text = name;
		}

		private void DisplayFileChanged()
		{
			this.Text = _currentFileName + "*";
			fileNameLabel.Text = _currentFileName + "*";
		}

		private void runButton_Click(object sender, EventArgs e)
		{
			Log($"{Environment.NewLine}================================={Environment.NewLine}");
			Interpreter.ExecuteString(_scintilla.Text);
		}
	}
}
