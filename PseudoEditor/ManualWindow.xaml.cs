using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

		private const string PageMissingError = "# Pagina lipsa din manual\n" +
		                                        "Pagina nu exista sau lipseste din folderul ManualPages. " +
		                                        "Paginile manualului pot fi descarcate de pe GitHub.";

		private List<string> _fileNames = new List<string>
		{
			"Cuprins",
			"Ghidul editorului",
			"Tipuri si variabile",
			"Instructiuni",
			"Algoritmi de baza"
		};

		public ManualWindow()
		{
			InitializeComponent();

			Viewer.Pipeline = new MarkdownPipelineBuilder().UseSupportedExtensions().Build();

			LoadButtonsForPages();
		}

		private void LoadButtonsForPages()
		{
			if (Directory.Exists(_manualPagesPath))
			{
				foreach (var fileName in _fileNames)
				{
					var filePath = Path.Combine(_manualPagesPath, $"{fileName}{MarkdownExt}");
					CreateButton(fileName, File.Exists(filePath) ? filePath : null);
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
	}
}
