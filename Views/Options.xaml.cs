using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Number_Guessing_Game.Views
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Page
    {
        public Options()
        {
            InitializeComponent();
        }

        public void navigateToHome(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("Views/Index.xaml", UriKind.Relative));

        }
        public void navigateToOptions(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("Views/Options.xaml", UriKind.Relative));

        }
    }
}
