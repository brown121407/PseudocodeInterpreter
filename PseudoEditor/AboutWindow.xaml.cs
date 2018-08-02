using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace PseudoEditor
{
	/// <summary>
	/// Interaction logic for AboutWindow.xaml
	/// </summary>
	public partial class AboutWindow : Window
	{
		public AboutWindow()
		{
			InitializeComponent();
		}


		private void GitHubButton_OnClick(object sender, RoutedEventArgs e)
		{
			Process.Start("https://github.com/brown121407/PseudocodeInterpreter");
		}

		private void TwitterButton_OnClick(object sender, RoutedEventArgs e)
		{
			Process.Start("https://twitter.com/brown121407");
		}

		private void InstagramButton_OnClick(object sender, RoutedEventArgs e)
		{
			Process.Start("https://www.instagram.com/brown121407/");
		}

		private void EmailButton_OnClick(object sender, RoutedEventArgs e)
		{
			Process.Start("mailto://brown121407@gmail.com");
		}

		private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			Process.Start(e.Uri.ToString());
		}
	}
}
