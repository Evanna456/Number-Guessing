using System;
using System.Windows;

namespace WPF_Number_Guessing_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Configs.WindowResponsive myWindowResponsive = new Configs.WindowResponsive();

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