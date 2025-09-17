using System.Windows;

namespace PMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private const string LightThemePath = "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml";
        //private const string DarkThemePath = "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml";
        private const string LightThemePath = "Themes/LightTheme.xaml";
        private const string DarkThemePath = "Themes/DarkTheme.xaml";

        public MainWindow()
        {
            InitializeComponent();

            // Set the toggle button state based on the current theme
            ThemeToggleButton.IsChecked = IsDarkThemeApplied();
            ThemeToggleButton.Checked += ThemeToggleButton_Checked;
            ThemeToggleButton.Unchecked += ThemeToggleButton_Unchecked;
        }

        private void ThemeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ApplyTheme(DarkThemePath);
        }

        private void ThemeToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ApplyTheme(LightThemePath);
        }

        private void ApplyTheme(string themePath)
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;

            // Remove existing theme dictionaries
            for (int i = dictionaries.Count - 1; i >= 0; i--)
            {
                var md = dictionaries[i];
                if (md.Source != null &&
                    (md.Source.OriginalString.Contains("Light") || md.Source.OriginalString.Contains("Dark")))
                {
                    dictionaries.RemoveAt(i);
                }
            }

            // Add the selected theme
            var themeDict = new ResourceDictionary() { Source = new System.Uri(themePath, System.UriKind.RelativeOrAbsolute) };
            dictionaries.Add(themeDict);
        }

        private bool IsDarkThemeApplied()
        {
            return Application.Current.Resources.MergedDictionaries
                .Any(md => md.Source != null && md.Source.OriginalString.Contains("Dark"));
        }
    }
}