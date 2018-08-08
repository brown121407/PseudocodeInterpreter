using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Markdig;
using Markdig.Wpf;

namespace PseudoEditor
{
	/// <summary>
	/// Interaction logic for ManualWindow.xaml
	/// </summary>
	public partial class ManualWindow : Window
	{
		private readonly string _manualPagesPath = $"{Directory.GetCurrentDirectory()}/ManualPages/";
		private const string MarkdownExt = ".md";
		private const string ManualUriScheme = "manual";

		private const string PageMissingError = "# Pagina lipsa din manual\n" +
		                                        "Pagina nu exista sau lipseste din folderul ManualPages. " +
		                                        "Paginile manualului pot fi descarcate de pe GitHub.";

		private readonly List<string> _fileNames = new List<string>
		{
			"cuprins",
			"ghidul_editorului",
			"tipuri_si_variabile",
			"instructiuni",
			"algoritmi"
		};

		public ManualWindow()
		{
			InitializeComponent();

			Viewer.Pipeline = new MarkdownPipelineBuilder().UseSupportedExtensions().Build();

			LoadButtonsForPages();

			Viewer.Loaded += async (sender, args) =>
			{
				var firstFilePath = Path.Combine(_manualPagesPath, $"{_fileNames[0]}{MarkdownExt}");
				if (File.Exists(firstFilePath))
				{
					Viewer.Markdown = await File.OpenText(firstFilePath).ReadToEndAsync();
				}
				else
				{
					Viewer.Markdown = PageMissingError;
				}
			};
		}

		private void LoadButtonsForPages()
		{
			if (Directory.Exists(_manualPagesPath))
			{
				foreach (var fileName in _fileNames)
				{
					var filePath = Path.Combine(_manualPagesPath, $"{fileName}{MarkdownExt}");

					var buttonContent = fileName.Replace('_', ' ').ToUpper();

					CreateButton(buttonContent, File.Exists(filePath) ? filePath : null);
				}
			}
		}

		private void CreateButton(string content, string fileToOpen)
		{
			var button = new Button
			{
				Content = content,
				Margin = new Thickness(8)
			};

			if (fileToOpen == null)
			{
				button.Click += (sender, args) => Viewer.Markdown = PageMissingError;
			}
			else
			{
				button.Click += async (sender, args) => Viewer.Markdown = await File.OpenText(fileToOpen).ReadToEndAsync();
			}

			PanelButtons.Children.Add(button);
		}

		private async void Hyperlink_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			var uri = new Uri(e.Parameter.ToString());
			if (uri.Scheme == ManualUriScheme)
			{
				var filePath = Path.Combine(_manualPagesPath, uri.Host);
				if (File.Exists(filePath))
				{
					Viewer.Markdown = await File.OpenText(filePath).ReadToEndAsync();
				}
				else
				{
					Viewer.Markdown = PageMissingError;
				}
			}
			else
			{
				Process.Start(e.Parameter.ToString());
			}
		}
	}
}
