using System;
using System.Collections.Generic;
using System.Diagnostics;
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
