using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Number_Guessing_Game.Views.AboutWindowPages
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

        private void openGithubLink(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Evanna456/WPF-Number-Guessing-Game",
                UseShellExecute = true
            });
        }

        //END
    }
}