using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Number_Guessing_Game.Views
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        public Index()
        {
            InitializeComponent();
        }

        private void navigateToHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/Index.xaml", UriKind.Relative));
        }

        private void navigateToGame(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/Game.xaml", UriKind.Relative));
        }

        private void navigateToOptions(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/Options.xaml", UriKind.Relative));
        }

        private void showAboutWindow(object sender, RoutedEventArgs e)
        {
            AboutWindow myAboutWindow = new AboutWindow();
            myAboutWindow.Show();
        }
    }
}