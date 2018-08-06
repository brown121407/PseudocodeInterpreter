using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PseudoEditor
{
	/// <summary>
	/// Interaction logic for PreferencesWindow.xaml
	/// </summary>
	public partial class PreferencesWindow : Window
	{
		private readonly Preferences _preferences;

		public PreferencesWindow(Preferences preferences)
		{
			InitializeComponent();

			_preferences = preferences;
			ToggleOpenLastFile.IsChecked = preferences.OpenLastFile;
		}

		private void PreferencesWindow_OnLoaded(object sender, RoutedEventArgs e)
		{
			ComboBoxFontName.ItemsSource = _preferences.FontNames;
			ComboBoxFontName.SelectedItem = _preferences.FontName;
			ComboBoxFontName.SelectionChanged += ComboBoxFontName_OnSelectionChanged;

			ComboBoxFontSize.ItemsSource = _preferences.FontSizes;
			ComboBoxFontSize.SelectedItem = _preferences.FontSize;
			ComboBoxFontSize.SelectionChanged += ComboBoxFontSize_OnSelectionChanged;
		}

		private void ComboBoxFontName_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			_preferences.FontName = ComboBoxFontName.SelectedItem.ToString();
		}

		private void ComboBoxFontSize_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			_preferences.FontSize = (int) ComboBoxFontSize.SelectedItem;
		}

		private void ToggleOpenLastFile_OnChecked(object sender, RoutedEventArgs e)
		{
			_preferences.OpenLastFile = true;
		}

		private void ToggleOpenLastFile_OnUnchecked(object sender, RoutedEventArgs e)
		{
			_preferences.OpenLastFile = false;
		}
	}
}
