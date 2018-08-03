using System.Windows.Input;

namespace PseudoEditor
{
	public static class CustomCommands
	{
		public static readonly RoutedUICommand Execute = new RoutedUICommand
		(
			"Execute",
			"Execute",
			typeof(CustomCommands),
			new InputGestureCollection()
			{
				new KeyGesture(Key.F5, ModifierKeys.Control)
			}
		);

		public static readonly RoutedUICommand About = new RoutedUICommand
		(
			"About",
			"About",
			typeof(CustomCommands)
		);

		public static readonly RoutedUICommand Preferences = new RoutedUICommand
		(
			"Preferences",
			"Preferences",
			typeof(CustomCommands)
		);
	}
}
