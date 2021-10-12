using System;
using System.Collections.Generic;
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
using WPF_Number_Guessing_Game.Configs;

namespace WPF_Number_Guessing_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Configs.WindowResponsive myWindowResponsive = new Configs.WindowResponsive();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void load(object sender, RoutedEventArgs e)
        {
            myWindowResponsive.windowConfigCreate();
            myWindowResponsive.windowConfigLoad();

        }

        private void updateWindowSize(object sender, EventArgs e)
        {

            myWindowResponsive.windowConfigUpdate();

        }

    }
}
