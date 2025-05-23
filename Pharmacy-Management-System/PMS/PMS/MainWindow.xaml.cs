using System.Windows;

namespace PMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string LightThemePath = "View/Theme/LightTheme.xaml";
        private const string DarkThemePath = "View/Theme/DarkTheme.xaml";

        public MainWindow()
        {
            InitializeComponent();
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
                    (md.Source.OriginalString.Contains("LightTheme.xaml") || md.Source.OriginalString.Contains("DarkTheme.xaml")))
                {
                    dictionaries.RemoveAt(i);
                }
            }
            // Add the selected theme
            var themeDict = new ResourceDictionary() { Source = new System.Uri(themePath, System.UriKind.Relative) };
            dictionaries.Add(themeDict);
        }
    }
}